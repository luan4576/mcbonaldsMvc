using System;
using mcbonaldsMvc.Models;
using mcbonaldsMvc.Repositories;
using mcbonaldsMvc.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcbonaldsMvc.Controllers
{
    public class PedidoController : AbstractController
    {

        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();
        ShakeRepository shakeRepository = new ShakeRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index()
        {
            var hamburguers = hamburguerRepository.ObterTodos();
            var shakes = shakeRepository.ObterTodos();
            
            PedidoViewModel pedido = new PedidoViewModel();

            pedido.Hamburguers = hamburguers;
            pedido.Shakes = shakes;

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                pedido.NomeUsuario = nomeUsuarioLogado;
            }

                var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
                if(clienteLogado !=null)
                {
                    pedido.cliente = clienteLogado;
                }

                pedido.NomeUsuario = ObterUsuarioNomeSession();

            return View(pedido);
        }

        public IActionResult Registrar(IFormCollection form)
        {
            Pedido pedido = new Pedido();

            Shake shake = new Shake();
            var nomeShake = form["shake"];
            shake.Nome = nomeShake;
            shake.Preco = shakeRepository.ObterPrecoDe(nomeShake);

            pedido.Shake = shake;


            var nomeHamburguer = form["hamburguer"];
            Hamburguer hamburguer = new Hamburguer(nomeHamburguer,hamburguerRepository.ObterPrecoDe(nomeHamburguer));

            pedido.Hamburguer = hamburguer;

            Cliente cliente = new Cliente()
            {
                Nome = form ["nome"],
                Endereco = form["endereco"],
                Telefone = form ["telefone"],
                Email = form ["email"]
            };

            pedido.Cliente = cliente;

            pedido.DataDoPedido = DateTime.Now;

            pedido.PrecoTotal = hamburguer.Preco + shake.Preco;

            pedidoRepository.Inserir(pedido);

            

            return View("Sucesso");
        }
    }
}
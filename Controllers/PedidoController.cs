using System;
using mcbonaldsMvc.Models;
using mcbonaldsMvc.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcbonaldsMvc.Controllers
{
    public class PedidoController : Controller
    {

        PedidoRepository pedidoRepository = new PedidoRepository();
        HamburguerRepository hamburguerRepository = new HamburguerRepository();
        public IActionResult Index()
        {
            var hamburguers = hamburguerRepository.ObterTodos();
            return View();
        }

        public IActionResult Registrar(IFormCollection form)
        {
            Pedido pedido = new Pedido();

            Shake shake = new Shake();
            shake.Nome = form["shake"];
            shake.Preco = 0.0;

            pedido.shake = shake;

            Hamburguer hamburguer = new Hamburguer(form["hamburguer"], 0.0);

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

            pedido.PrecoTotal = 0.0;

            pedidoRepository.Inserir(pedido);

            

            return View("Sucesso");
        }
    }
}
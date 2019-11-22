using System;
using mcbonaldsMvc.Repositories;
using mcbonaldsMvc.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcbonaldsMvc.Controllers {
    public class ClienteController : AbstractController {

        private ClienteRepository clienteRepositry = new ClienteRepository();
        private PedidoRepository pedidoRepository = new PedidoRepository();
        [HttpGet]
        public IActionResult Login () {
            return View ();
        }

        [HttpPost]
        
        public IActionResult Login (IFormCollection form)
        
        {
            ViewData["Action"] = "Login";
            try {

                System.Console.WriteLine ("===============");
                System.Console.WriteLine (form["email"]);
                System.Console.WriteLine (form["senha"]);
                System.Console.WriteLine ("===============");

                var usuario = form["email"];
                var senha = form ["senha"];

                var cliente = clienteRepositry.ObterPor(usuario);

                if (cliente != null)
                {
                    if(cliente.Senha.Equals(senha))
                    {
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                    

                        return RedirectToAction("Historico","Cliente");
                    }
                    else
                    {
                        return View ("Erro" , new RespostaViewModel("Senha incorreta"));
                    }
                }
                else
                {

                return View ("Erro", new RespostaViewModel($"Usuario{usuario} não foi encontrado"));
                }

            } catch (Exception e) {
                System.Console.WriteLine (e.StackTrace);
                return View ("erro");
            }
        }

        public IActionResult Historico()
        {
            var emailCliente = ObterUsuarioSession();
            var pedidos = pedidoRepository.ObterTodosPorCliente(emailCliente);

            return View (new HistoricoViewModel (){
                Pedidos = pedidos
            });
        }
    }

}
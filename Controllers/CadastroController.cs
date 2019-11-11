using System;
using mcbonaldsMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcbonaldsMvc.Controllers {
    public class CadastroController : Controller {
        public IActionResult Index () {
            return View ();
        }

        public IActionResult CadastrarCliente (IFormCollection form) {
            ViewData["Acction"] = "Cadastro";
            try{
            Cliente cliente = new Cliente (form["nome"],
                form["endereço"],
                form["telefone"],
                form["senha"],
                form["email"],
                DateTime.Parse (form["data-nascimento"]));

            System.Console.WriteLine (form["nome"]);
            return View ("Sucesso");
            }
            catch(Exception e)
            {
                return View("Erro");
            }
        }
    }
}
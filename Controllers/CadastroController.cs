using System;
using mcbonaldsMvc.Models;
using mcbonaldsMvc.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcbonaldsMvc.Controllers {
    public class CadastroController : Controller {

        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index () {
            return View ();
        }

        public IActionResult CadastrarCliente (IFormCollection form) {
            ViewData["Action"] = "Cadastro";
            try{
            Cliente cliente = new Cliente (form["nome"],
                form["endereço"],
                form["telefone"],
                form["senha"],
                form["email"],
                DateTime.Parse (form["data-nascimento"]));

                clienteRepository.Inserir(cliente);


            return View ("Sucesso");
            }
            catch(Exception e)
            {
                return View("Erro");
            }
        }
    }
}
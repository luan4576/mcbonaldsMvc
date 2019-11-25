using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mcbonaldsMvc.Models;
using mcbonaldsMvc.ViewModels;

namespace mcbonaldsMvc.Controllers
{
    public class HomeController : AbstractController
    {
        public IActionResult Index()
        {
            
            return View(new BaseViewModel()
            {
                NomeView = "Home",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
            });
        }

    }
}

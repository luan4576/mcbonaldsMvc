using System.Collections.Generic;
using mcbonaldsMvc.Models;

namespace mcbonaldsMvc.ViewModels
{
    public class PedidoViewModel
    {
        public List<Hamburguer> Hamburguers {get;set;}

        public List<Shake> Shakes {get;set;}
        public string NomeUsuario{get;set;}

        public Cliente cliente{get;set;}
        public PedidoViewModel()
        {
            this.Hamburguers = new List<Hamburguer>();
            this.Shakes = new List<Shake>();
            this.NomeUsuario = "Jovem";
            this.cliente = new Cliente();
        }

        
    }
}
using System;
using mcbonaldsMvc.Enums;

namespace mcbonaldsMvc.Models
{
    public class Pedido
    {
        public ulong Id {get;set;}
        public Cliente Cliente {get;set;}
        public Hamburguer Hamburguer {get;set;}
        public Shake Shake {get;set;}
        public DateTime DataDoPedido{get;set;}
        public double PrecoTotal {get;set;}
        public uint Status {get;set;}

        public Pedido()
        {
            this.Cliente = new Cliente();
            this.Hamburguer = new Hamburguer();
            this.Shake = new Shake();
            this.Id = 0;
            this.Status = (uint) StatusPedido.PENDENTE;
        }

    }
}
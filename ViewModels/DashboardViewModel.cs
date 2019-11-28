using System.Collections.Generic;
using mcbonaldsMvc.Models;

namespace mcbonaldsMvc.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
    public List<Pedido> pedidos {get;set;}
    public uint PedidosAprovados {get;set;}
    public uint PedidosReprovados {get;set;}
    public uint PedidosPendentes {get;set;}
    public DashboardViewModel()
    {
        this.pedidos = new List<Pedido>();
    }




    }
}
using System.Collections.Generic;
using mcbonaldsMvc.Models;

namespace mcbonaldsMvc.ViewModels
{
    public class HistoricoViewModel : BaseViewModel
    {
        public List<Pedido> Pedidos {get;set;}
    }
}
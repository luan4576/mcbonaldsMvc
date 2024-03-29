using mcbonaldsMvc.Enums;
using mcbonaldsMvc.Repositories;
using mcbonaldsMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace mcbonaldsMvc.Controllers
{
    public class AdministradorController : AbstractController
    {
        PedidoRepository pedidoRepository = new PedidoRepository();

        [HttpGet]
        public IActionResult DashBoard()
        {
            var tipoUsuarioSessao = uint.Parse(ObterUsuarioTipoSession());
            if(tipoUsuarioSessao.Equals( (uint) tipoUsuario.ADMINISTRADOR))
            {

            var pedidos = pedidoRepository.ObterTodos();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            foreach (var pedido in pedidos)
            {
                switch (pedido.Status)
                {
                    case (uint) StatusPedido.REPROVADO :
                    dashboardViewModel.PedidosReprovados++;

                    break;
                    case (uint) StatusPedido.APROVADO:
                    dashboardViewModel.PedidosAprovados++;
                    break;
                    default:
                    dashboardViewModel.PedidosPendentes++;
                    dashboardViewModel.pedidos.Add(pedido);
                    break;
                }
            }

            dashboardViewModel.NomeView = "Dashboard";
            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

            return View(dashboardViewModel);
            }
            return View("Erro",new RespostaViewModel()
            {
                NomeView ="Dashboard",
                Mensagem = "so administrador"
            })
        }
        
    }
}
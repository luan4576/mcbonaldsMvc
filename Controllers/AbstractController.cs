using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcbonaldsMvc.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "cliente_email"; 

        protected const string SESSION_CLIENTE_NOME = "cliente_nome";
         protected const string SESSION_CLIENTE_USUARIO = "cliente_usuario";

        protected string ObterUsuarioSession()
        {
            var email = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            if(!string.IsNullOrEmpty(email))
            {
                return email;
            }
            else
            {
                return"";
            }
        }

        protected string ObterUsuarioNomeSession()
        {
            var email = HttpContext.Session.GetString(SESSION_CLIENTE_NOME);
            if(!string.IsNullOrEmpty(email))
            {
                return email;
            }
            else
            {
                return"";
            }
        }
         protected string ObterUsuarioTipoSession()
        {
            var tipoUsuario = HttpContext.Session.GetString(SESSION_CLIENTE_USUARIO);
            if(!string.IsNullOrEmpty(tipoUsuario))
            {
                return tipoUsuario;
            }
            else
            {
                return"";
            }
        }

        

    }
}
using System.Net;
using System.Web.Http;
using Application2.Domain.Interfaces.Service;
using Autenticacao.API.Models;

namespace Autenticacao2.Controllers
{
	[RoutePrefix("api/recoverpassword")]
	public class RecoverPasswordController : ApiController
	{
		private readonly IUsuarioService _usuarioService;

		public RecoverPasswordController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		[HttpPost]
        [Authorize(Roles = "User")]
		public IHttpActionResult Index(string Email, string token)
		{
		    var login = new Login()
			{
				Email = Email
			};
		    return _usuarioService.VerificarEmail(login.Email) ? Ok(_usuarioService.EnviarToken(login.Email,token) != null ? "Email enviado com sucesso" : "Usuario ou senhas invalido") : Ok( "Usuario ou senhas invalido");
		}
	}
}

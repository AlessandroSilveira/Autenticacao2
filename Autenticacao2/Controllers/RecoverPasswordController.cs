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
		//private readonly ICustomMessage _customMessasge;

		public RecoverPasswordController(IUsuarioService usuarioService)
		{
			//_customMessasge = customMessasge;
			_usuarioService = usuarioService;
		}

		[HttpPost]
	
		public IHttpActionResult Index(string Email)
		{
			var login = new Login()
			{
				Email = Email
			};

			return _usuarioService.VerificarEmail(login.Email)
			? Ok(_usuarioService.EnviarToken(login.Email)) as IHttpActionResult
			: CustomMessage.Create(HttpStatusCode.Unauthorized, "Usuario ou senhas invalido");
		}
	}
}

using System;
using System.Web.Http;
using Application2.Domain.Interfaces.Service;

namespace Autenticacao2.Controllers
{
	[RoutePrefix("api/newpassword")]
	
	public class NewPasswordController : ApiController
	{
		private readonly IUsuarioService _usuarioService;

		public NewPasswordController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		[HttpPost]
		[Authorize(Roles = "User")]
		public IHttpActionResult NovaSenha(string token, string id, string senha)
		{
			var usuarioid = new Guid(id);
			var usuario = _usuarioService.ObterPorId(usuarioid);

			var validatoken = _usuarioService.ValidarToken(token, id);

			return validatoken == ""
				? (usuario == null
					? Ok("Usuário Inválido")
					: Ok(_usuarioService.NovaSenha(usuario,token,senha) ? "Senha Alterada com Sucesso" : "Erro ao alterar senha"))
				: Ok("Token Inválido");
		}
	}
}
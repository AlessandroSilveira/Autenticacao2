using System;
using System.Net;
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


		    return usuario == null ? Ok("Usuário Inválido") : Ok(_usuarioService.NovaSenha(usuario) ? "Senha Alterada com Sucesso" : "Erro ao alterar senha");

			
		}
	}
}
using System;
using System.Web.Http;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;

namespace Autenticacao2.Controllers
{
	[RoutePrefix("api/profile")]
	public class ProfileController : ApiController
	{
		private readonly IUsuarioService _usuarioService;

		public ProfileController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		// GET: api/Profile/5
		public IHttpActionResult Get(Guid id)
		{
			var usuario = _usuarioService.ObterPorId(id);
			var token = _usuarioService.ObterToken(usuario);
			return ValidateToken(id, token, usuario);
		}

		public IHttpActionResult ValidateToken(Guid id, string token, Usuario usuario)
		{
			var retorno = _usuarioService.Autenticar(usuario.Email, usuario.Senha);
			return retorno
				? Ok("Token  Inválido") as IHttpActionResult
				: Ok(_usuarioService.ObterPorId(id));
		}
	}
}

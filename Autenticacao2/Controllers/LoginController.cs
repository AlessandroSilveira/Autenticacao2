using System.Web.Http;
using Application2.Domain.Interfaces.Service;
using Autenticacao.API.Models;

namespace Autenticacao2.Controllers
{
	[RoutePrefix("api/login")]
	public class LoginController : ApiController
	{
		private readonly IUsuarioService _usuarioService;
		private readonly ICriptografia _criptografia;
		public LoginController(IUsuarioService usuarioService, ICriptografia criptografia)
		{
			_criptografia = criptografia;
			_usuarioService = usuarioService;
		}

		// POST: api/login
		[HttpPost]
		public IHttpActionResult Autenticar(string Email, string Senha, string token)
		{
			return _usuarioService.VerificarEmail(Email)
				? (_usuarioService.VerificarEmailESenha(Email, _criptografia.Hash(Senha))
					? (_usuarioService.Autenticar(Email, _criptografia.Hash(Senha), token)
						? Ok(_usuarioService.Get(f => f.Email.Equals(Email) && f.Senha.Equals(_criptografia.Hash(Senha)))) as IHttpActionResult
						: Ok("E-mail informado é inválido.") as IHttpActionResult)
					: Ok("E-mail informado é inválido.")) as IHttpActionResult
				: Ok("E-mail informado é inválido.") as IHttpActionResult;
		}
	}
}


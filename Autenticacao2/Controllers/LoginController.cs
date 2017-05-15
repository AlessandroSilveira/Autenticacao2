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
		public IHttpActionResult Autenticar(string Email, string Senha)
		{
			var login = new Login
			{
				Email = Email,
				Senha = Senha
			};

			return _usuarioService.VerificarEmail(login.Email)
				? (_usuarioService.VerificarEmailESenha(login.Email, _criptografia.Hash(login.Senha))
					? (IHttpActionResult) Ok(_usuarioService.Autenticar(login.Email, _criptografia.Hash(login.Senha)))
					:Ok("Usuário e/ou senha inválidos."))
				:Ok("E-mail informado é inválido.");
		}
	}
}


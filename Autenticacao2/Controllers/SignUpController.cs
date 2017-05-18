using System;
using System.Collections.Generic;
using System.Web.Http;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;
using Autenticacao2.Infra.Data.Interfaces;


namespace Autenticacao2.Controllers
{
	[RoutePrefix("api/signup")]
	public class SignUpController : ApiController
	{
		private readonly IUsuarioService _usuarioService;
		private readonly IUnitOfWork _uokOfWork;
		private readonly ICriptografia _criptografia;
		

		public SignUpController(IUsuarioService usuarioService, ICriptografia criptografia, IUnitOfWork uokOfWork)
		{
			_criptografia = criptografia;
			_uokOfWork = uokOfWork;
			_usuarioService = usuarioService;
		}

		// POST: api/SignUp
		[HttpPost]
		[Authorize(Roles = "User")]
		public IHttpActionResult Index(string token,string nome,string email, string senha, string ddd, List<Telefone> telefone)
		//public IHttpActionResult Index(Usuario usuario)
		{
			try
			{
				if (_usuarioService.VerificarEmail(email))
					return Ok("E-mail já cadastrado.");
				
				var novoUsuario = new Usuario(nome, email, _criptografia.Hash(senha),
					telefone, token);

				_uokOfWork.BeginTransaction();
				_usuarioService.Adicionar(novoUsuario);
				
				_uokOfWork.Commit();

				return Ok(novoUsuario.UsuarioId);
			}
			catch (Exception ex)
			{
				return Ok(false);
			}
		}
	}
}

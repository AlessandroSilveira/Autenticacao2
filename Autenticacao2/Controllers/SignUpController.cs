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
		private readonly IJwt _jwt;

		public SignUpController(IUsuarioService usuarioService, ICriptografia criptografia, IJwt jwt, IUnitOfWork uokOfWork)
		{
			_criptografia = criptografia;
			_jwt = jwt;
			_uokOfWork = uokOfWork;
			_usuarioService = usuarioService;
		}

		// POST: api/SignUp
		[HttpPost]
		[Authorize(Roles = "User")]
		public IHttpActionResult Index(string token,string nome,string email, string senha, string ddd,string telefone)
		{

			var usuario = new Usuario()
			{
				Nome = nome,
				Email = email,
				Senha = senha,
				Token = token,
				Telefones = new List<Telefone>()
			};
			
			try
			{
				if (_usuarioService.VerificarEmail(email))
					return Ok("E-mail já cadastrado.");

				var novoUsuario = new Usuario(usuario.Nome, usuario.Email, _criptografia.Hash(usuario.Senha),
					usuario.Telefones, usuario.Token);

				_uokOfWork.BeginTransaction();
				_usuarioService.Adicionar(novoUsuario);
				_uokOfWork.Commit();

				return Ok("Usuário Criado com sucesso");
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}
	}
}

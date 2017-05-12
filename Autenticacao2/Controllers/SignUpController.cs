﻿using System;
using System.Net;
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
		//private readonly ICustomMessage _customMessasge;
		private readonly IJwt _jwt;

		public SignUpController(IUsuarioService usuarioService,  ICriptografia criptografia, IJwt jwt, IUnitOfWork uokOfWork)
		{
			//_customMessasge = customMessasge;
			_criptografia = criptografia;
			_jwt = jwt;
			_uokOfWork = uokOfWork;
			_usuarioService = usuarioService;
		}

		// POST: api/SignUp
		[HttpPost]
		public IHttpActionResult Registrar(Usuario usuario)
		{
			try
			{
				if (_usuarioService.VerificarEmail(usuario.Email))
					return CustomMessage.Create(HttpStatusCode.Conflict, "E-mail já cadastrado.");

				var novoUsuario = new Usuario(usuario.Nome, usuario.Email, _criptografia.Hash(usuario.Senha),
					usuario.Telefones, _jwt.GenerateToken(usuario.Email));

				_uokOfWork.BeginTransaction();
				_usuarioService.Adicionar(novoUsuario);
				_uokOfWork.Commit();

				return Created("Usuario", novoUsuario);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}

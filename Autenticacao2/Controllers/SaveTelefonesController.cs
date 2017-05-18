using System;
using System.Collections.Generic;
using System.Web.Http;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;
using Autenticacao2.Infra.Data.Interfaces;

namespace Autenticacao2.Controllers
{
	[RoutePrefix("api/SaveTelefones")]
	public class SaveTelefonesController : ApiController
	{

		private readonly ITelefoneService _telefoneService;
		private readonly IUsuarioService _usuarioService;
		private readonly IUnitOfWork _uokOfWork;

		public SaveTelefonesController(ITelefoneService telefoneService, IUnitOfWork uokOfWork, IUsuarioService usuarioService)
		{
			_telefoneService = telefoneService;
			_uokOfWork = uokOfWork;
			_usuarioService = usuarioService;
		}

		[HttpPost]
		[Authorize(Roles = "User")]
		public IHttpActionResult Index(string id, string ddd, string numero)
		{
			try
			{
				if (_usuarioService.ObterPorId(new Guid(id)) == null)
					return Ok("Usuário Inválido");

				var novotelefone = new Telefone()
				{
					UsuarioId = (new Guid(id)),
					Ddd = ddd,
					Numero = numero,
					TelefoneId = new Guid()
					
				};

				_uokOfWork.BeginTransaction();
				_telefoneService.Adicionar(novotelefone);
				_uokOfWork.Commit();

				return Ok("Dados salvos com sucesso");
			}
			catch (Exception ex)
			{
				return Ok(false);
			}
		}
	}
}
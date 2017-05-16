using System;
using System.Collections.Generic;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;
using Autenticacao2.Application.Interfaces;
using Autenticacao2.Infra.Data.Interfaces;

namespace Autenticacao2.Application
{
	public class UsuarioAppService : ApplicationService, IUsuarioAppService
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioAppService(IUsuarioService usuarioService, IUnitOfWork uow) : base(uow)
		{
			_usuarioService = usuarioService;
		}

		public void Dispose()
		{
			_usuarioService.Dispose();
		}

		public Usuario Adicionar(Usuario obj)
		{
			BeginTansaction();
			var objreturn =  _usuarioService.Adicionar(obj);
			Commit();
			return objreturn;
		}

		public Usuario ObterPorId(Guid id)
		{
			return _usuarioService.ObterPorId(id);
		}

		public IEnumerable<Usuario> ObterTodos()
		{
			return _usuarioService.ObterTodos();
		}

		public Usuario Atualizar(Usuario obj)
		{
			return _usuarioService.Atualizar(obj);
		}

		public void Remover(Guid id)
		{
			_usuarioService.Remover(id);
		}

		public int SaveChanges()
		{
			return _usuarioService.SaveChanges();
		}

		public bool VerificarEmail(string email)
		{
			return _usuarioService.VerificarEmail(email);
		}

		public bool VerificarEmailESenha(string loginEmail, string hash)
		{
			return _usuarioService.VerificarEmailESenha(loginEmail, hash);
		}

		public object Autenticar(string loginEmail, string hash,string token)
		{
			return _usuarioService.Autenticar(loginEmail, hash,token);
		}

		public string ValidarTokenDoUsuario(string token, string id)
		{
			return _usuarioService.ValidarToken(token, id);
		}

		public object Get(Func<object, object> func)
		{
			throw new NotImplementedException();
		}

		public void Criar(Usuario novoUsuario)
		{
			_usuarioService.Adicionar(novoUsuario);
		}
	}
}
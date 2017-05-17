using System;
using System.Collections.Generic;
using Application2.Domain.Entities;

namespace Application2.Domain.Interfaces.Service
{
	public interface IUsuarioService : IDisposable
	{
		Usuario Adicionar(Usuario obj);
		Usuario ObterPorId(Guid id);
		IEnumerable<Usuario> ObterTodos();
		Usuario Atualizar(Usuario obj);
		void Remover(Guid id);
		int SaveChanges();
		string ValidarToken(string token, string id);
		bool VerificarEmail(string email);
		bool VerificarEmailESenha(string loginEmail, string hash);
		bool Autenticar(string loginEmail, string hash,string token);
		Usuario Get(Func<Usuario,bool> func);
		Usuario EnviarToken(string loginEmail,string token);
		bool NovaSenha(Usuario usuario,string token,string senha);
		string AutalizarToken(Usuario usuario);
	}
}
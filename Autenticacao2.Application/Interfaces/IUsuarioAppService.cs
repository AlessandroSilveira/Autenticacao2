using System;

namespace Autenticacao2.Application.Interfaces
{
	public interface IUsuarioAppService : IDisposable
	{
		bool VerificarEmail(string email);
		bool VerificarEmailESenha(string loginEmail, string hash);
		object Autenticar(string loginEmail, string hash);
		string ValidarTokenDoUsuario(string token, string id);
	}
}
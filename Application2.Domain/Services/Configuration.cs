using System;
using Application2.Domain.Interfaces.Service;
using static System.Configuration.ConfigurationSettings;

namespace Autenticacao2.Domain.Services
{
	public class Configuration : IConfiguration
	{
		public string ObterSmtp()
		{
			return AppSettings["host"];
		}

		public string ObterEmailFrom()
		{
			return AppSettings["From"];
		}

		public string ObterPortaServidorEmail()
		{
			return AppSettings["port"];
		}

		public string GetBodyEmailRecuperarSenha(string token,string id)
		{
			return "Link para alteração de senha http://localhost:53151/CadastrarNovaSenha?token=" + token+ "&id="+id;
		}

		public int ObterTempoLogado()
		{
			return Convert.ToInt32(AppSettings["TempoLogado"]);
		}

		public string ObterPasswordEmail()
		{
			return AppSettings ["passwordEmail"];
		}
	}
}

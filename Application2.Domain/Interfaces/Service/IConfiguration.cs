namespace Application2.Domain.Interfaces.Service
{
	public interface IConfiguration
	{
		string ObterSmtp();
		string ObterEmailFrom();
		string ObterPortaServidorEmail();
		string GetBodyEmailRecuperarSenha(string token,string id);
		int ObterTempoLogado();
	}
}
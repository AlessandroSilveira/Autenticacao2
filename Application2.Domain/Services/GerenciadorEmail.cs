using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;

namespace Application2.Domain.Services
{
	public class GerenciadorEmail : IGerenciadorEmail
	{
		public EnviaEmailBuilder Builder { get; }
		private readonly IConfiguration _configuration;

		public GerenciadorEmail(IConfiguration configuration, EnviaEmailBuilder builder)
		{
			_configuration = configuration;
			Builder = builder;
		}
		public EnviaEmailBuilder EnviarEmail(Usuario usuario, string token)
		{
			Builder.BuildBody("");
			Builder.BuildBcc("");
			Builder.BuildBody(_configuration.GetBodyEmailRecuperarSenha(token, usuario.UsuarioId.ToString()));
			Builder.BuildCc("");
		    Builder.BuildSubject("");
			Builder.BuildFrom(_configuration.ObterEmailFrom());
			Builder.BuildPort(_configuration.ObterPortaServidorEmail());
			Builder.BuildSmtpServer(_configuration.ObterSmtp());
			Builder.BuildTo(usuario.Email);
			return Builder;
		}
	}
}

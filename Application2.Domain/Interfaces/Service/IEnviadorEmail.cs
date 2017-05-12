using Application2.Domain.Services;

namespace Application2.Domain.Interfaces.Service
{
	public interface IEnviadorEmail
	{
		void EnviarTokenPorEmail(EnviaEmailBuilder dadosEmail);
	}
}
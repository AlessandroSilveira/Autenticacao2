using Application2.Domain.Entities;
using Application2.Domain.Services;

namespace Application2.Domain.Interfaces.Service
{
	public interface IGerenciadorEmail
	{
		EnviaEmailBuilder EnviarEmail(Usuario usuario, string token);
	}
}

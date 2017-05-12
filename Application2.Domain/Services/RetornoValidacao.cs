using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;

namespace Application2.Domain.Services
{
	public class RetornoValidacao : IItensValidacao
	{
		public string Validacao(string token, Usuario usuario, string retorno, int tempologado)
		{
			return retorno;
		}

		public IItensValidacao Proximo { get; set; }
	}
}
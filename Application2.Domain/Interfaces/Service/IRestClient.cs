using RestSharp;

namespace Application2.Domain.Interfaces.Service
{
	public interface IRestClientDomain
	{
		RestClient NovaConexao();
	}
}
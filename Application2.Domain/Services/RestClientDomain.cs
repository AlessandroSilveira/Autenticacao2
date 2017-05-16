using System.Diagnostics.CodeAnalysis;
using Application2.Domain.Interfaces.Service;
using RestSharp;

namespace Application2.Domain.Services
{
	[ExcludeFromCodeCoverage]
	public class RestClientDomain : IRestClientDomain
	{
		public RestClient NovaConexao()
		{
			return new RestClient("http://localhost:53151/");
		}
	}
}

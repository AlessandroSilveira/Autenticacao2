using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application2.Domain.Interfaces.Service
{
	public interface ICustomMessage
	{
		CustomMessage Create(HttpStatusCode statusCode, string message);
	
		
	}
}
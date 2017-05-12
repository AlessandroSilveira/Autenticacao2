namespace Application2.Domain.Interfaces.Service
{
	public interface IJwt
	{
		string GenerateToken(string username);
	}
}

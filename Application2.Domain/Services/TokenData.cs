using System.Diagnostics.CodeAnalysis;

namespace Application2.Domain.Services
{
	[ExcludeFromCodeCoverage]
	public class TokenData
	{
		public string AccessToken { get; set; }
		public string TokenType { get; set; }
		public int ExpiresIn { get; set; }
	}
}
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application2.Domain.Interfaces.Service;
using Microsoft.IdentityModel.Tokens;

namespace Autenticacao2.Infra.Security
{
	public class Jwt : IJwt
	{
		private static IConfiguration _configuration;

		public Jwt(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public const string Secret = "856FECBA3B06519C8DDDBC80BB080553";

		//public  string GenerateToken(string username)
		//{
		//    var expireMinutes = "30";

		//	var symmetricKey = Convert.FromBase64String(Secret);
		//	var tokenHandler = new JwtSecurityTokenHandler();

		//	var now = DateTime.UtcNow;
		//	var tokenDescriptor = new SecurityTokenDescriptor
		//	{
		//		Subject = new ClaimsIdentity(new[]
		//		{
		//			new Claim(ClaimTypes.Name, username)
		//		}),
		//		Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
		//		SigningCredentials =
		//			new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
		//	};

		//	var stoken = tokenHandler.CreateToken(tokenDescriptor);
		//	var token = tokenHandler.WriteToken(stoken);

		//	return token;
		//}
		
	}
}
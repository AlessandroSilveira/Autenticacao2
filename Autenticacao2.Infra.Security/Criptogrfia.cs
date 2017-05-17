using System;
using System.Security.Cryptography;
using System.Text;
using Application2.Domain.Interfaces.Service;

namespace Autenticacao2.Infra.Security
{
	public class Criptografia : ICriptografia
	{
		public static string Hash(string senha)
		{
			var bytes = new UTF8Encoding().GetBytes(senha);
			byte[] hashBytes;
			using (var algorithm = new SHA512Managed())
			{
				hashBytes = algorithm.ComputeHash(bytes);
			}

			return Convert.ToBase64String(hashBytes);
		}

		string ICriptografia.Hash(string senha)
		{
			return Hash(senha);
		}
	}
}

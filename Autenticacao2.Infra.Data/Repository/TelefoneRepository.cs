using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Repository;
using Autenticacao2.Infra.Data.Context;

namespace Autenticacao2.Infra.Data.Repository
{
	public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
	{
		public TelefoneRepository(AutenticacaoContext db) : base(db)
		{
		}
	}
}
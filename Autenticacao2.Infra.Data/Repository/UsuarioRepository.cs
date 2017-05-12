using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Repository;
using Autenticacao2.Infra.Data.Context;

namespace Autenticacao2.Infra.Data.Repository
{
	public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(AutenticacaoContext db) : base(db)
		{
		}

	}
}
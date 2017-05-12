using System;
using Application2.Domain.Entities;

namespace Application2.Domain.Interfaces.Repository
{
	public interface IUsuarioRepository : IRepository<Usuario>
	{
		Usuario Get(Func<Usuario, bool> func);
	}
}
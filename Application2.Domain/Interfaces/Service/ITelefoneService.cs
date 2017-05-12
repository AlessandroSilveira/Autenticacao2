using System;
using System.Collections.Generic;
using Application2.Domain.Entities;

namespace Application2.Domain.Interfaces.Service
{
	public interface ITelefoneService : IDisposable
	{
		Telefone Adicionar(Telefone obj);
		Telefone ObterPorId(Guid id);
		IEnumerable<Telefone> ObterTodos();
		Telefone Atualizar(Telefone obj);
		void Remover(Guid id);
		int SaveChanges();
	}
}
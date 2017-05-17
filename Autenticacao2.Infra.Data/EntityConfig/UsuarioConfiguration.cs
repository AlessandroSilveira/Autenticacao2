﻿using System.Data.Entity.ModelConfiguration;
using Application2.Domain.Entities;

namespace Autenticacao2.Infra.Data.EntityConfig
{
	public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
	{
		public UsuarioConfiguration()
		{
			HasKey(c => c.UsuarioId);

			Property(c => c.Nome)
				.IsRequired()
				.HasMaxLength(150);

			Property(c => c.Email)
				.IsRequired()
				.HasMaxLength(150);

			Property(c => c.Senha)
				.IsRequired()
				.HasMaxLength(250);

			Property(c => c.Token)
				.IsRequired()
				.HasMaxLength(500);

			ToTable("Usuarios");
		}
	}
}

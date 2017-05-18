using System;
using System.Collections.Generic;

namespace Application2.Domain.Entities
{
	public class Usuario
	{
		public Usuario()
		{
			UsuarioId = new Guid();
		}

		public Usuario(string nome, string email, string senha, List<Telefone> telefones, string token)
		{
			Nome = nome;
			Email = email;
			Senha = senha;
			Telefones = telefones;
			Token = token;

			UsuarioId = Guid.NewGuid();
			DataCriacao = DateTime.Now;
			DataAtualizacao = DateTime.Now;
			DataUltimoLogin = DateTime.Now;
		}


		public Guid UsuarioId { get;  set; }
		public string Nome { get;  set; }
		public string Email { get;  set; }
		public string Senha { get;  set; }
		public DateTime DataCriacao { get;  set; }
		public DateTime DataAtualizacao { get;  set; }
		public DateTime DataUltimoLogin { get;  set; }
		public string Token { get;  set; }

		public virtual List<Telefone> Telefones { get; set; } 

		public void AtualizarDataUltimoLogin()
		{
			DataUltimoLogin = DateTime.Now;
		}
	}
}

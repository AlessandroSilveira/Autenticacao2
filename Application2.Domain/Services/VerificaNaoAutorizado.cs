﻿using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;

namespace Application2.Domain.Services
{
	public class VerificaNaoAutorizado : IItensValidacao
	{
		public IItensValidacao Proximo { get; set; }
		public string Validacao(string token, Usuario usuario, string retorno)
		{
			retorno = usuario.Token.Equals(token) ? "Não autorizado." : "";
			return Proximo.Validacao(token, usuario, retorno);
		}
	}
}
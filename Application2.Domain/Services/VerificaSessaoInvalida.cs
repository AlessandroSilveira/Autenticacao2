﻿using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;

namespace Application2.Domain.Services
{
	public class VerificaSessaoInvalida : IItensValidacao
	{
		public IItensValidacao Proximo { get; set; }
		public string Validacao(string token, Usuario usuario, string retorno, int tempologado)
		{
			retorno = !usuario.Token.Equals(token) && usuario.DataUltimoLogin.Minute > tempologado ? "Sessão inválida." : "";
			return Proximo.Validacao(token, usuario, retorno,tempologado);
		}
	}
}
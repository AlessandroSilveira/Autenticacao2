﻿using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;

namespace Application2.Domain.Services
{
	public class VerificaNaoAutorizado :  IItensValidacao
	{
		public IItensValidacao Proximo { get; set; }
		public string Validacao(string token, Usuario usuario, string retorno, int tempologado)
		{
			retorno = !string.IsNullOrWhiteSpace(token) &&(usuario.Token.Equals(token) || usuario.DataUltimoLogin.Minute >= tempologado) ? "Não autorizado.": "";
			return Proximo.Validacao(token, usuario, retorno,tempologado);
		}
	}
}
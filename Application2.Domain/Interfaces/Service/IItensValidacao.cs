﻿using Application2.Domain.Entities;

namespace Application2.Domain.Interfaces.Service
{
	public interface IItensValidacao
	{
		string Validacao(string token, Usuario usuario, string retorno, int tempologado);
		IItensValidacao Proximo { get; set; }
	}
}
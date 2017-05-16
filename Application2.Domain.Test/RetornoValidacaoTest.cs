using System;
using System.Collections.Generic;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;
using Application2.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Application2.Domain.Test
{
	[TestFixture]
	public class RetornoValidacaoTest
	{
		private MockRepository _repository;
		private Mock<IItensValidacao> _itensValidacaoMock;
		private RetornoValidacao _retornoValidacao;
		

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_itensValidacaoMock = _repository.Create<IItensValidacao>();
			_retornoValidacao = new RetornoValidacao();
		}

		[Test]
		public void ValidacaoTeste()
		{
			//Arrange
			Guid id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
			var usuario = new Usuario() { UsuarioId = id, Nome = "Ale", Senha = "1234567890", Email = "teste4@teste.com", Token = "456", Telefones = new List<Telefone>() };
		
			//Act
			_retornoValidacao.Validacao(usuario.Token, usuario, It.IsAny<string>(), It.IsAny<int>());

			//Arrange
			_repository.VerifyAll();
		}
	}
}
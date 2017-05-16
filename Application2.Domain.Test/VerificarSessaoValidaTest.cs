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
	public class VerificarSessaoValidaTest
	{
		private MockRepository _repository;
		private Mock<IItensValidacao> _itensValidacaoMock;
		private VerificaSessaoInvalida _verificaSessaoInvalida;
		public IItensValidacao Proximo { get; set; }

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_itensValidacaoMock = _repository.Create<IItensValidacao>();
			_verificaSessaoInvalida = new VerificaSessaoInvalida();
		}


		[Test]
		public void ValidacaoTeste()
		{
			//Arrange
			Guid id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
			var usuario = new Usuario() { UsuarioId = id, Nome = "Ale", Senha = "1234567890", Email = "teste4@teste.com", Token = "456", Telefones = new List<Telefone>() };

			_itensValidacaoMock.Setup(a=>a.Proximo).Verifiable();
			
			_itensValidacaoMock.Setup(a => a.Validacao(usuario.Token, usuario, It.IsAny<string>(), It.IsAny<int>())).Returns(It.IsAny<string>()).Verifiable();

			//Act
			_verificaSessaoInvalida.Validacao(usuario.Token, usuario, It.IsAny<string>(), It.IsAny<int>());

			//Arrange
			_repository.VerifyAll();
		}
	}
}

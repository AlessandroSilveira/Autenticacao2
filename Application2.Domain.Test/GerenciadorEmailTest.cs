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
	public class GerenciadorEmailTest
	{
		private MockRepository _repository;
		private GerenciadorEmail _gerenciadorEmail;
		private Mock<IGerenciadorEmail> _IgerenciadorEmail;
		private Mock<IConfiguration> _configurationMock;
		private EnviaEmailBuilder _emailBuilder;

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_IgerenciadorEmail = _repository.Create<IGerenciadorEmail>();
			_configurationMock = _repository.Create<IConfiguration>();
			 _emailBuilder = new EnviaEmailBuilder();
			_gerenciadorEmail = new GerenciadorEmail(_configurationMock.Object, _emailBuilder);

		}

		[Test]
		public void EnviarEmailTeste()
		{
			//Arrange
			Guid id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
			var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
			var usuario = new Usuario() { UsuarioId = id, Nome = "Ale", Senha = senha, Email = "teste@teste.com", Token = "456", Telefones = new List<Telefone>() };

			_configurationMock.Setup(a=>a.GetBodyEmailRecuperarSenha(usuario.Token, usuario.UsuarioId.ToString())).Returns(It.IsAny<string>()).Verifiable();
			_configurationMock.Setup(a=>a.ObterEmailFrom()).Returns(It.IsAny<string>()).Verifiable();
			_configurationMock.Setup(a=>a.ObterPortaServidorEmail()).Returns(It.IsAny<string>()).Verifiable();
			_configurationMock.Setup(a=>a.ObterSmtp()).Returns(It.IsAny<string>()).Verifiable();

			//Act
			_gerenciadorEmail.EnviarEmail(usuario, usuario.Token);

			//Assert
			_repository.VerifyAll();
		}
	}
}
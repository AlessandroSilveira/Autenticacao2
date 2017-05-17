using System;
using System.Collections.Generic;
using System.Linq;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;
using Autenticacao2.Controllers;
using Moq;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class ProfileControllerTestes
	{
		private MockRepository _repository;
		private Mock<IUsuarioService> _mockUsuarioService;
		private ProfileController _profileController;

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_mockUsuarioService = _repository.Create<IUsuarioService>();
			_profileController = new ProfileController(_mockUsuarioService.Object);
		}

		[Test]
		public void TestGet()
		{
			//Arrange
			Guid id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
			Guid id2 = new Guid("c3158adf-158e-407d-9c16-6f3cbab8a524");
			Guid id3 = new Guid("48839961-0d93-4556-9408-cc7007d64125");

			IList<Usuario> usuarios = new List<Usuario>
			{
				new Usuario(){UsuarioId =id,Nome = "Ale",Senha = "1234567890",Email = "teste@teste.com",Token = "123",Telefones = new List<Telefone>()},
				new Usuario(){UsuarioId =id2,Nome = "Ale2",Senha = "1234567890",Email = "teste1@teste.com",Token = "123",Telefones = new List<Telefone>()},
				new Usuario(){UsuarioId =id3,Nome = "Ale3",Senha = "1234567890",Email = "teste3@teste.com",Token = "123",Telefones = new List<Telefone>()}
			};

			_mockUsuarioService.Setup(a => a.ObterPorId(id)).Returns((Guid i) => usuarios.Single(x => x.UsuarioId == i));
			_mockUsuarioService.Setup(a => a.Autenticar(It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>())).Returns(It.IsAny<bool>()).Verifiable();

			//Act
			_profileController.Get(id);

			//Assert
			_repository.VerifyAll();
		}
	}
}

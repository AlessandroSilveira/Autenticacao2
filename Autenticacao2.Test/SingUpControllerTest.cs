using System;
using System.Collections.Generic;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Repository;
using Application2.Domain.Interfaces.Service;
using Autenticacao2.Controllers;
using Autenticacao2.Infra.Data.Interfaces;
using Moq;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class SingUpControllerTest
	{
		private MockRepository _repository;
		private Mock<IUsuarioService> _mockUsuarioService;
		private Mock<IUsuarioRepository> _usuarioRepositoryMock;
		private Mock<IUnitOfWork> _mockUow;
		private Mock<ICustomMessage> _mockCustomMessage;
		private Mock<ICriptografia> _mockCriptografia;
		private Mock<IJwt> _mockJwt;
		private SignUpController _signUpController;

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_mockCustomMessage = _repository.Create<ICustomMessage>();
			_mockUsuarioService = _repository.Create<IUsuarioService>();
			_mockUow = _repository.Create<IUnitOfWork>();
			_mockCriptografia = _repository.Create<ICriptografia>();
			_mockJwt = _repository.Create<IJwt>();
			_usuarioRepositoryMock = _repository.Create<IUsuarioRepository>();
			_signUpController = new SignUpController(_mockUsuarioService.Object, _mockCriptografia.Object,_mockJwt.Object,_mockUow.Object);
		}

		

		[Test]
		public void RegisterTest()
		{
			//Arrange
			Guid id = new Guid("e54684cc-fe03-4388-8cbe-87eb6b019b56");
			var usuario = new Usuario(){UsuarioId = id, Nome = "Ale",Senha = "1234567890",Email = "teste2@teste.com",Token = "123",Telefones = new List<Telefone>(), DataUltimoLogin = DateTime.Now, DataAtualizacao = DateTime.Now,DataCriacao = DateTime.Now};
			
			

			_mockCriptografia.Setup(a=>a.Hash(usuario.Senha)).Returns(It.IsAny<string>()).Verifiable();

			_mockUsuarioService.Setup(a => a.VerificarEmail(usuario.Email)).Returns(It.IsAny<bool>()).Verifiable();

			_mockUow.Setup(a=>a.BeginTransaction()).Verifiable();
			
			//_usuarioRepositoryMock.Setup(a=>a.Adicionar(usuario)).Returns(usuario).Verifiable();

			//_mockUow.Setup(a=>a.Commit()).Verifiable();

			//Act
			_signUpController.Index(usuario.Token, usuario.Nome, usuario.Email,usuario.Senha, It.IsAny<string>(),It.IsAny<string>());
		
			//Assert
			_repository.VerifyAll();

		}
	}
}

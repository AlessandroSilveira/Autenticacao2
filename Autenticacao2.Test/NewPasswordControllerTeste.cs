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
	public class NewPasswordControllerTeste
	{
		private MockRepository _repository;
		private Mock<IUsuarioService> _mockUsuarioService;
		private Mock<ICriptografia> _criptografiaMock;
		private NewPasswordController _newPasswordController;

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_mockUsuarioService = _repository.Create<IUsuarioService>();
			_criptografiaMock = _repository.Create<ICriptografia>();
			_newPasswordController = new NewPasswordController(_mockUsuarioService.Object);
		}

		[Test]
		public void NovaSenhaTestTokenVálido()
		{
			//Arrange
			var token = "rH_8nXB9CgR10poT08CmIAjTqTAjsDdDeprz8WdStVUSSAb0eTxfZhoHfkVqcnfyNf3h_lTyPpUtfz8GbLIptXCWeOPp4a8l5ofTFbkFcMXVKmeRkwqYE2iBitSclYP32yrBiRjzJ2oxOOcLxgjyiyocAnSoTvfi0Sjhvf38JOdtTpl9rblFYLTTNRDcNAgn3b-L9BszRreniKZN7AaubVUO6DUlkTjMlHgtCWsrogayw579GguM6JD-SF4y-gnbEJUHgGO3gGCV-HoY88yDy6Mgps-2HwJF1AK7zkU_evM";
			var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";

			Guid id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
			Guid id2 = new Guid("c3158adf-158e-407d-9c16-6f3cbab8a524");
			Guid id3 = new Guid("48839961-0d93-4556-9408-cc7007d64125");
			
			IList<Usuario> usuarios = new List<Usuario>
			{
				new Usuario(){UsuarioId = id,Nome = "Ale",Senha = senha,Email = "teste@teste.com",Token = token,Telefones = new List<Telefone>()},
				new Usuario(){UsuarioId = id2,Nome = "Ale2",Senha = "1234567890",Email = "teste1@teste.com",Token = "123",Telefones = new List<Telefone>()},
				new Usuario(){UsuarioId = id3,Nome = "Ale3",Senha = "1234567890",Email = "teste3@teste.com",Token = "123",Telefones = new List<Telefone>()}
			};

			var usuario = usuarios.FirstOrDefault(a => a.UsuarioId == id);

			_mockUsuarioService.Setup(mr => mr.ObterPorId(id)).Returns((Guid i) => usuarios.Single(x => x.UsuarioId == i));

			_mockUsuarioService.Setup(a=>a.ValidarToken(token,id.ToString())).Returns(It.IsAny<string>()).Verifiable();

			//_mockUsuarioService.Setup(a=>a.NovaSenha(usuario, token)).Returns(It.IsAny<bool>()).Verifiable();

			////Act
			_newPasswordController.NovaSenha(token, id.ToString(), senha);

			//Assert
			_repository.VerifyAll();
		}

	}
}
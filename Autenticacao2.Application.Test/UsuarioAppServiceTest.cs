using System;
using System.Collections.Generic;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;
using Autenticacao2.Infra.Data.Interfaces;
using Moq;
using NUnit.Framework;

namespace Autenticacao2.Application.Test
{
    [TestFixture]
    public class UsuarioAppServiceTest
    {
        private MockRepository _repository;
        private Mock<IUsuarioService> _iUsuarioServiceMock;
        private Mock<IUnitOfWork> _uoWMock;
        private UsuarioAppService _usuarioAppService;

        [SetUp]
        public void Setup()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _iUsuarioServiceMock = _repository.Create<IUsuarioService>();
            _uoWMock = _repository.Create<IUnitOfWork>();
            _usuarioAppService = new UsuarioAppService(_iUsuarioServiceMock.Object, _uoWMock.Object);
        }

        [Test]
        public void DisposeTest()
        {
            //Arrange
            _iUsuarioServiceMock.Setup(a => a.Dispose()).Verifiable();

            //Act
            _usuarioAppService.Dispose();

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void AdicionarTest()
        {
            //Arrange

            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _iUsuarioServiceMock.Setup(a => a.Adicionar(usuario)).Returns(usuario).Verifiable();
            _uoWMock.Setup(a=>a.BeginTransaction()).Verifiable();
            _uoWMock.Setup(a => a.Commit()).Verifiable();

            //Act
            _usuarioAppService.Adicionar(usuario);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void ObterPorIdTest()
        {
            //Arrange

            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _iUsuarioServiceMock.Setup(a => a.ObterPorId(usuario.UsuarioId)).Returns(usuario).Verifiable();

            //Act
            _usuarioAppService.ObterPorId(usuario.UsuarioId);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void ObterTodosTest()
        {
            //Arrange
            _iUsuarioServiceMock.Setup(a => a.ObterTodos()).Returns(It.IsAny<IEnumerable<Usuario>>()).Verifiable();

            //Act
            _usuarioAppService.ObterTodos();

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void AtualizarTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _iUsuarioServiceMock.Setup(a => a.Atualizar(usuario)).Returns(usuario).Verifiable();

            //Act
            _usuarioAppService.Atualizar(usuario);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void RemoverTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _iUsuarioServiceMock.Setup(a => a.Remover(usuario.UsuarioId)).Verifiable();

            //Act
            _usuarioAppService.Remover(usuario.UsuarioId);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void SaveChangesTest()
        {
            //Arrange
            _iUsuarioServiceMock.Setup(a => a.SaveChanges()).Returns(It.IsAny<int>()).Verifiable();

            //Act
            _usuarioAppService.SaveChanges();

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void VerificarEmailTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _iUsuarioServiceMock.Setup(a => a.VerificarEmail(usuario.Email)).Returns(It.IsAny<bool>()).Verifiable();

            //Act
            _usuarioAppService.VerificarEmail(usuario.Email);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void VerificarEmailESenhaTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _iUsuarioServiceMock.Setup(a => a.VerificarEmailESenha(usuario.Email,usuario.Senha)).Returns(It.IsAny<bool>()).Verifiable();

            //Act
            _usuarioAppService.VerificarEmailESenha(usuario.Email,usuario.Senha);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void AutenticarTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _iUsuarioServiceMock.Setup(a => a.Autenticar(usuario.Email, usuario.Senha,usuario.Token)).Returns(It.IsAny<bool>()).Verifiable();

            //Act
            _usuarioAppService.Autenticar(usuario.Email, usuario.Senha,usuario.Token);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void ValidarTokenDoUsuarioTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

           _iUsuarioServiceMock.Setup(a=>a.ValidarToken(usuario.Token,usuario.UsuarioId.ToString())).Returns(It.IsAny<string>()).Verifiable();

            //Act
            _usuarioAppService.ValidarTokenDoUsuario(usuario.Token, usuario.UsuarioId.ToString());

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void GetTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _iUsuarioServiceMock.Setup(a => a.Get(It.IsAny<Func<Usuario, bool>>())).Returns(usuario).Verifiable();

            //Act
            _usuarioAppService.Get(It.IsAny<Func<Usuario, bool>>());

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void CriarTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var senha = "ErAyJqbYvpxujNXlXcbHkgyqo53xSquS1ePqk0DRyKTT0LjkMU8fbvExukvxzrkYarh8gBrw1clbG++4ztriuQ==";
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = senha,
                Email = "teste@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _iUsuarioServiceMock.Setup(a => a.Adicionar(usuario)).Returns(usuario).Verifiable();

            //Act
            _usuarioAppService.Criar(usuario);

            //Assert
            _repository.VerifyAll();
        }
    }
}

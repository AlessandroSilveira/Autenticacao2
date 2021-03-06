﻿using System;
using System.Collections.Generic;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Repository;
using Application2.Domain.Interfaces.Service;
using Application2.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Application2.Domain.Test
{
    [TestFixture]
    public class TestDomainService
    {
        private MockRepository _repository;
        private Mock<IUsuarioRepository> _mockUsuarioRepository;
        private Mock<ICriptografia> _mockCriptografia;
        private Mock<IGerenciadorEmail> _mockGerenciadorEmail;
        private Mock<IEnviadorEmail> _enviadoremailMock;
        private readonly Mock<IUsuarioService> _mockUsuarioService = new Mock<IUsuarioService>();
        public IUsuarioService MockUsuarioServicey;
        private UsuarioService _usuarioService;

        [SetUp]
        public void Setup()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _mockCriptografia = _repository.Create<ICriptografia>();
            _mockUsuarioRepository = _repository.Create<IUsuarioRepository>();
            _mockGerenciadorEmail = _repository.Create<IGerenciadorEmail>();
            _enviadoremailMock = _repository.Create<IEnviadorEmail>();
            _usuarioService = new UsuarioService(_mockUsuarioRepository.Object, _mockCriptografia.Object,
            _mockGerenciadorEmail.Object, _enviadoremailMock.Object);
        }

        [Test]
        public void ObterPorIdTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            _mockUsuarioRepository.Setup(a => a.ObterPorId(id)).Returns(It.IsAny<Usuario>()).Verifiable();

            //Act
            _usuarioService.ObterPorId(id);
            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void ObterTodosTest()
        {
            //Arrange
            _mockUsuarioRepository.Setup(a => a.ObterTodos()).Returns(It.IsAny<IEnumerable<Usuario>>()).Verifiable();

            //Act
            _usuarioService.ObterTodos();
            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void AdicionarTeste()
        {
            //Arrange
            var id2 = new Guid("c3158adf-158e-407d-9c16-6f3cbab8a524");
            var usuario = new Usuario
            {
                UsuarioId = id2,
                Nome = "Ale",
                Senha = "1234567890",
                Email = "teste4@teste.com",
                Token = "123",
                Telefones = new List<Telefone>()
            };

            _mockUsuarioRepository.Setup(a => a.Adicionar(usuario)).Returns(It.IsAny<Usuario>()).Verifiable();

            //Act
            _usuarioService.Adicionar(usuario);
            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void AtualizarTeste()
        {
            //Arrange
            var id2 = new Guid("c3158adf-158e-407d-9c16-6f3cbab8a524");
            var usuario = new Usuario
            {
                UsuarioId = id2,
                Nome = "Ale",
                Senha = "1234567890",
                Email = "teste4@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };
            _mockUsuarioRepository.Setup(a => a.Atualizar(usuario)).Returns(It.IsAny<Usuario>()).Verifiable();

            //Act
            _usuarioService.Atualizar(usuario);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void RemoverTeste()
        {
            //Arrange
            var id2 = new Guid("c3158adf-158e-407d-9c16-6f3cbab8a524");
            _mockUsuarioRepository.Setup(a => a.Remover(id2)).Verifiable();

            //Act
            _usuarioService.Remover(id2);
            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void DisposeTeste()
        {
            //Arrange
            _mockUsuarioRepository.Setup(a => a.Dispose()).Verifiable();
            //Act
            _usuarioService.Dispose();
            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void ValidadorTokenTest()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = "1234567890",
                Email = "teste4@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            //Act
            _usuarioService.ValidadorToken(usuario.Token, usuario);
            //Assert
            _repository.VerifyAll();
        }


        [Test]
        public void NovaSenhaTeste()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = "1234567890",
                Email = "teste4@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };
            var senha = "123456";

           
            _mockUsuarioService.Setup(a => a.NovaSenha(usuario, usuario.Token, senha))
                .Returns(It.IsAny<bool>())
                .Verifiable();
            _mockUsuarioRepository.Setup(a => a.ObterPorId(usuario.UsuarioId)).Returns(usuario).Verifiable();


            //Act
            _usuarioService.NovaSenha(usuario, usuario.Token, senha);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void NovaSenhaTesteInvalido()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = "1234567890",
                Email = "teste4@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };
            var senha = "123456";
            _mockUsuarioService.Setup(a => a.NovaSenha(usuario, usuario.Token, senha))
                .Returns(It.IsAny<bool>())
                .Verifiable();
            _mockUsuarioRepository.Setup(a => a.ObterPorId(usuario.UsuarioId)).Returns(usuario).Verifiable();

            //Act
            _usuarioService.NovaSenha(usuario, usuario.Token, senha);
            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void SaveChangesTest()
        {
            //Arrange
            _mockUsuarioRepository.Setup(a => a.SaveChanges()).Returns(It.IsAny<int>()).Verifiable();
            //Act
            _usuarioService.SaveChanges();
            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void VerificarEmailTeste()
        {
            //Arrange
            var id = new Guid("a566c99b-1ca7-48f9-a85e-68efd6ce2c2f");
            var usuario = new Usuario
            {
                UsuarioId = id,
                Nome = "Ale",
                Senha = "1234567890",
                Email = "teste4@teste.com",
                Token = "456",
                Telefones = new List<Telefone>()
            };

            _mockUsuarioService.Setup(a => a.VerificarEmail(usuario.Email)).Returns(It.IsAny<bool>()).Verifiable();
            _mockUsuarioRepository.Setup(a => a.Get(It.IsAny<Func<Usuario, bool>>())).Returns(usuario).Verifiable();

            //Act
            _usuarioService.VerificarEmail(usuario.Email);
            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void VerificarEmailESenhaTeste()
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

            _mockUsuarioService.Setup(a => a.VerificarEmailESenha(usuario.Email, usuario.Senha))
                .Returns(It.IsAny<bool>())
                .Verifiable();
            _mockUsuarioRepository.Setup(a => a.Get(It.IsAny<Func<Usuario, bool>>())).Returns(usuario).Verifiable();

            //Act
            _usuarioService.VerificarEmailESenha(usuario.Email, usuario.Senha);
            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void EnviarTokenTest()
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

            _mockUsuarioService.Setup(a => a.Get(It.IsAny<Func<Usuario, bool>>())).Returns(usuario).Verifiable();
            _mockUsuarioRepository.Setup(a => a.Get(It.IsAny<Func<Usuario, bool>>())).Returns(usuario).Verifiable();
            _mockGerenciadorEmail.Setup(a => a.EnviarEmail(usuario, usuario.Token))
                .Returns(It.IsAny<EnviaEmailBuilder>())
                .Verifiable();
            _enviadoremailMock.Setup(a => a.EnviarTokenPorEmail(It.IsAny<EnviaEmailBuilder>())).Verifiable();

            //Act
            _usuarioService.EnviarToken(usuario.Email, usuario.Token);
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

            _mockUsuarioRepository.Setup(a => a.Get(It.IsAny<Func<Usuario, bool>>())).Returns(usuario).Verifiable();
            _mockUsuarioService.Setup(a => a.Get(It.IsAny<Func<Usuario, bool>>())).Returns(usuario).Verifiable();

            //Act
            _usuarioService.Get(It.IsAny<Func<Usuario, bool>>());

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

            _mockUsuarioService.Setup(a => a.Autenticar(usuario.Email, usuario.Senha, usuario.Token))
                .Returns(It.IsAny<bool>())
                .Verifiable();
            _mockUsuarioRepository.Setup(a => a.Get(It.IsAny<Func<Usuario, bool>>())).Returns(usuario).Verifiable();
            _mockUsuarioRepository.Setup(a => a.Atualizar(usuario)).Returns(usuario).Verifiable();

            //Act
            _usuarioService.Autenticar(usuario.Email, usuario.Senha, usuario.Token);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void AutenticarRetornandoNullTest()
        {
            //Arrange
            var usuario = new Usuario();

            _mockUsuarioService.Setup(a => a.Autenticar(null, null, null)).Returns(It.IsAny<bool>()).Verifiable();
            _mockUsuarioRepository.Setup(a => a.Get(It.IsAny<Func<Usuario, bool>>())).Returns(usuario).Verifiable();


            //Act
            _usuarioService.Autenticar(null, null, null);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void AtualizarTokenTest()
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

            _mockUsuarioService.Setup(a => a.AutalizarToken(usuario)).Returns(It.IsAny<string>()).Verifiable();
            _mockUsuarioRepository.Setup(a => a.Atualizar(usuario)).Returns(usuario).Verifiable();


            //Act
            _usuarioService.AutalizarToken(usuario);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void ValidarTokenTest()
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

            _mockUsuarioRepository.Setup(a => a.ObterPorId(usuario.UsuarioId)).Returns(usuario).Verifiable();

            //Act
            _usuarioService.ValidarToken(usuario.Token,usuario.UsuarioId.ToString());

            //Assert
            _repository.VerifyAll();
        }


    }
}
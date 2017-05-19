using System;
using System.Collections.Generic;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;
using Moq;
using NUnit.Framework;

namespace Autenticacao2.Application.Test
{
    [TestFixture]
    public class TelefoneAppServiceTest
    {
        private MockRepository _repository;
        private Mock<ITelefoneService> _iTelefoneServiceMock;
        private TelefoneAppService _telefoneAppService;
        
        [SetUp]
        public void Setup()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _iTelefoneServiceMock = _repository.Create<ITelefoneService>();
            _telefoneAppService = new TelefoneAppService(_iTelefoneServiceMock.Object);
        }

        [Test]
        public void DisposeTest()
        {
            //Arrange
            _iTelefoneServiceMock.Setup(a=>a.Dispose()).Verifiable();

            //Act
            _telefoneAppService.Dispose();

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void AdicionarTest()
        {
            //Arrange

            var telefone = new Telefone()
            {
                Ddd = "11",
                Numero = "111111111",
                TelefoneId = new Guid(),
                UsuarioId = new Guid()
            };

            _iTelefoneServiceMock.Setup(a => a.Adicionar(telefone)).Returns(telefone).Verifiable();

            //Act
            _telefoneAppService.Adicionar(telefone);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void ObterPorIdTest()
        {
            //Arrange

            var telefone = new Telefone()
            {
                Ddd = "11",
                Numero = "111111111",
                TelefoneId = new Guid(),
                UsuarioId = new Guid()
            };

            _iTelefoneServiceMock.Setup(a => a.ObterPorId(telefone.TelefoneId)).Returns(telefone).Verifiable();

            //Act
            _telefoneAppService.ObterPorId(telefone.TelefoneId);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void ObterTodosTest()
        {
            //Arrange
            _iTelefoneServiceMock.Setup(a => a.ObterTodos()).Returns(It.IsAny<IEnumerable<Telefone>>()).Verifiable();

            //Act
            _telefoneAppService.ObterTodos();

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void AtualizarTest()
        {
            //Arrange
            var telefone = new Telefone()
            {
                Ddd = "11",
                Numero = "111111111",
                TelefoneId = new Guid(),
                UsuarioId = new Guid()
            };

            _iTelefoneServiceMock.Setup(a => a.Atualizar(telefone)).Returns(telefone).Verifiable();

            //Act
            _telefoneAppService.Atualizar(telefone);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void RemoverTest()
        {
            //Arrange
            var telefone = new Telefone()
            {
                Ddd = "11",
                Numero = "111111111",
                TelefoneId = new Guid(),
                UsuarioId = new Guid()
            };

            _iTelefoneServiceMock.Setup(a => a.Remover(telefone.TelefoneId)).Verifiable();

            //Act
            _telefoneAppService.Remover(telefone.TelefoneId);

            //Assert
            _repository.VerifyAll();
        }

        [Test]
        public void SaveChangesTest()
        {
            //Arrange
            _iTelefoneServiceMock.Setup(a => a.SaveChanges()).Returns(It.IsAny<int>()).Verifiable();

            //Act
            _telefoneAppService.SaveChanges();

            //Assert
            _repository.VerifyAll();
        }
    }
}

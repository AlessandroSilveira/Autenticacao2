using System;
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
	public class TelefoneServiceTest
	{
		private MockRepository _repository;
		private Mock<ITelefoneRepository> _telefoneRepositoryMock;
		private TelefoneService _telefoneServicer;

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_telefoneRepositoryMock = _repository.Create<ITelefoneRepository>();
			_telefoneServicer = new TelefoneService(_telefoneRepositoryMock.Object);
		}


		[Test]
		public void DisposeTest()
		{
			//Assert
			_telefoneRepositoryMock.Setup(a=>a.Dispose()).Verifiable();

			//Act
			_telefoneServicer.Dispose();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void AdicionarTelefoneTest()
		{
			//Arrange
			var Usuario = new Guid();
			var telefone = new Telefone() {Ddd = "11", Numero = "000000000", TelefoneId = new Guid(), UsuarioId = Usuario};

			_telefoneRepositoryMock.Setup(a=>a.Adicionar(telefone)).Returns(telefone).Verifiable();

			//Act
			_telefoneServicer.Adicionar(telefone);

			//Assert
			_repository.VerifyAll();

		}

		[Test]
		public void ObterPorIdTest()
		{
			//Arrange
			var Usuario = new Guid();
			var telefone = new Telefone() { Ddd = "11", Numero = "000000000", TelefoneId = new Guid(), UsuarioId = Usuario };

			_telefoneRepositoryMock.Setup(a => a.ObterPorId(telefone.TelefoneId)).Returns(telefone).Verifiable();

			//Act
			_telefoneServicer.ObterPorId(telefone.TelefoneId);

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void ObterTodosTest()
		{
			//Arrange
			_telefoneRepositoryMock.Setup(a => a.ObterTodos()).Returns(It.IsAny<IEnumerable<Telefone>>()).Verifiable();

			//Act
			_telefoneServicer.ObterTodos();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void AtualizarTest()
		{
			//Arrange
			var Usuario = new Guid();
			var telefone = new Telefone() { Ddd = "11", Numero = "000000000", TelefoneId = new Guid(), UsuarioId = Usuario };

			_telefoneRepositoryMock.Setup(a => a.Atualizar(telefone)).Returns(telefone).Verifiable();

			//Act
			_telefoneServicer.Atualizar(telefone);

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void RemoverTest()
		{
			//Arrange
			var Usuario = new Guid();
			var telefone = new Telefone() { Ddd = "11", Numero = "000000000", TelefoneId = new Guid(), UsuarioId = Usuario };

			_telefoneRepositoryMock.Setup(a => a.Remover(telefone.TelefoneId)).Verifiable();

			//Act
			_telefoneServicer.Remover(telefone.TelefoneId);

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void SaveChangesTest()
		{
			//Arrange
			_telefoneRepositoryMock.Setup(a => a.SaveChanges()).Returns(It.IsAny<int>()).Verifiable();

			//Act
			_telefoneServicer.SaveChanges();

			//Assert
			_repository.VerifyAll();
		}
	}
}

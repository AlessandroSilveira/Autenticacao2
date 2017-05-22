using Application2.Domain.Interfaces.Service;
using Application2.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Application2.Domain.Test
{
    [TestFixture]
	public class VerificaNaoAutorizadoTest
	{
		private MockRepository _repository;
		private Mock<IItensValidacao> _itensValidacaoMock;
		private VerificaNaoAutorizado _verificaNaoAutorizado;
		

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_itensValidacaoMock = _repository.Create<IItensValidacao>();
			_verificaNaoAutorizado = new VerificaNaoAutorizado();
		}

		[Test]
		public void ValidacaoTeste()
		{
			//Arrange
			var retornaValidacao = new RetornoValidacao();
		
			//Act
			_verificaNaoAutorizado.Proximo = retornaValidacao;
			//Arrange
			_repository.VerifyAll();
		}
	}
}
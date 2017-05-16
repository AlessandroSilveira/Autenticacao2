using System.Net;
using System.Threading;
using System.Web.Http;
using Application2.Domain.Interfaces.Service;
using Autenticacao2.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Application2.Domain.Test
{
	[TestFixture]
	public class CustomMessageTest
	{
		private MockRepository _repository;
		private Mock<ICustomMessage> _iCustomMessageMock;
		private Mock<IHttpActionResult> _iHttpActionMock;
		private CustomMessage _customMessage;


		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_iCustomMessageMock = _repository.Create<ICustomMessage>();
			_iHttpActionMock = _repository.Create<IHttpActionResult>();
			_customMessage = new CustomMessage(It.IsAny<HttpStatusCode>(),It.IsAny<string>());
		}

		[Test]
		public void CreateTest()
		{
			//Act
			_customMessage.Create(It.IsAny<HttpStatusCode>(), It.IsAny<string>());

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void ExecuteAsync()
		{
			//Act
			_customMessage.ExecuteAsync(It.IsAny<CancellationToken>());

			//Assert
			_repository.VerifyAll();
		}

	}
}

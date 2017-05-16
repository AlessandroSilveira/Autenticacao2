using Application2.Domain.Interfaces.Service;
using Application2.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Application2.Domain.Test
{
	[TestFixture]
	public class EmailBuilderTest
	{
		private MockRepository _repository;
		private Mock<IEmailBuilder> _iemailbuilderMock;
		private EmailBuilder _emailBuilder;

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_iemailbuilderMock = _repository.Create<IEmailBuilder>();
			_emailBuilder = new EmailBuilder();
		}

		[Test]
		public void GetFromTest()
		{
			//Act
			_emailBuilder.GetFrom();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void GetToTest()
		{
			//Act
			_emailBuilder.GetTo();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void GetCcTest()
		{
			//Act
			_emailBuilder.GetCc();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void GetBccTest()
		{
			//Act
			_emailBuilder.GetBcc();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void GetSubjectTest()
		{
			//Act
			_emailBuilder.GetSubject();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void GetBodyTest()
		{
			//Act
			_emailBuilder.GetBody();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void GetSmtpServerTest()
		{
			//Act
			_emailBuilder.GetSmtpServer();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void GetBodyFormatTest()
		{
			//Act
			_emailBuilder.GetBodyFormat();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void GetPortTest()
		{
			//Act
			_emailBuilder.GetPort();

			//Assert
			_repository.VerifyAll();
		}
	}
}
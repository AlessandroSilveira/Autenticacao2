using Application2.Domain.Interfaces.Service;
using Application2.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Application2.Domain.Test
{
	[TestFixture]
	public class EnviadorDeEmailTest
	{
		private MockRepository _repository;
		private Mock<IEnviadorEmail> _iEnviadorEmailMock;
		private Mock<IConfiguration> _iConfigurationMock;
		private EnviardorDeEmail _enviardorDeEmail;

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_iEnviadorEmailMock = _repository.Create<IEnviadorEmail>();
			_iConfigurationMock = _repository.Create<IConfiguration>();
			_enviardorDeEmail = new EnviardorDeEmail(_iConfigurationMock.Object);
		}

		[Test]
		public void EnviarTokenPorEmailTest()
		{
			var dadosEmail = new EnviaEmailBuilder()
			{
				Bcc = "",
				Body = "Email de Teste",
				BodyFormat = "HTML",
				Cc = "",
				From = "alesilver.si@gmail.com",
				Port = "587",
				SmtpServer = "smtp.gmail.com",
				Subject = "Teste",
				To = "alesssandro.silveira@concrete.com"
			};
		
			_iConfigurationMock.Setup(a=>a.ObterEmailFrom()).Returns(It.IsAny<string>()).Verifiable();
			_iConfigurationMock.Setup(a=>a.ObterPasswordEmail()).Returns(It.IsAny<string>()).Verifiable();

			_enviardorDeEmail.EnviarTokenPorEmail(dadosEmail);

			_repository.VerifyAll();
		}
	}
}

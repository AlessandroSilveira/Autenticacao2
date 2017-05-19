using Application2.Domain.Interfaces.Service;
using Autenticacao2.Domain.Services;
using Moq;
using NUnit.Framework;

namespace Application2.Domain.Test
{
	[TestFixture]
	public class ConfigurationTest
	{
		private MockRepository _repository;
		private Mock<IConfiguration> _iConfigurationMock;
		private Configuration _configuration;

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_iConfigurationMock = _repository.Create<IConfiguration>();
			_configuration = new Configuration();
		}

		[Test]
		public void ObterTempoLogadoTest()
		{
			//Act
			_configuration.ObterTempoLogado();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void ObterSmtpTest()
		{
			//Act
			_configuration.ObterSmtp();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void ObterEmailFromTest()
		{
			//Act
			_configuration.ObterEmailFrom();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void ObterPortaServidorEmailTest()
		{
			//Act
			_configuration.ObterPortaServidorEmail();

			//Assert
			_repository.VerifyAll();
		}

		[Test]
		public void GetBodyEmailRecuperarSenhaTest()
		{
			//Act
			_configuration.GetBodyEmailRecuperarSenha(It.IsAny<string>(), It.IsAny<string>());

			//Assert
			_repository.VerifyAll();
		}

        [Test]
        public void ObterPasswordEmailTest()
        {
            //Act
            _configuration.ObterPasswordEmail();

            //Assert
            _repository.VerifyAll();
        }
    }
}
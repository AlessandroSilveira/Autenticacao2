using Application2.Domain.Interfaces.Repository;
using Application2.Domain.Interfaces.Service;
using Autenticacao2.Controllers;
using Moq;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class RecoverPasswordControllerTest
	{
		private MockRepository _repository;
		private Mock<IUsuarioService> _mockUsuarioService;
		private Mock<ICustomMessage> _mockCustomMessage;
		private Mock<IUsuarioRepository> _mockusuarioRepository;
		private RecoverPasswordController _recoverPasswordr;

		[SetUp]
		public void Setup()
		{
			_repository = new MockRepository(MockBehavior.Strict);
			_mockCustomMessage = _repository.Create<ICustomMessage>();
			_mockUsuarioService = _repository.Create<IUsuarioService>();
			_mockusuarioRepository = _repository.Create<IUsuarioRepository>();
			_recoverPasswordr = new RecoverPasswordController(_mockUsuarioService.Object);
		}

		[Test]
		public void RecuperarSenhaTeste()
		{
			var Email = "teste@teste.com";
			var Senha = "1234567890";
			var token = "";

			_mockUsuarioService.Setup(a=>a.VerificarEmail(Email)).Returns(It.IsAny<bool>()).Verifiable();

			_recoverPasswordr = new RecoverPasswordController(_mockUsuarioService.Object);

			_recoverPasswordr.Index(Email,token);

			_repository.VerifyAll();
		}
	}
}
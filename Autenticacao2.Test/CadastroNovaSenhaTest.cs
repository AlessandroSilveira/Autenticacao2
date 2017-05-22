using System.Web.Mvc;
using Autenticacao2.Controllers;
using Moq;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class CadastroNovaSenhaControllerTest
	{
		private CadastrarNovaSenhaController _cadastroController;

		[SetUp]
		public void Setup()
		{
			_cadastroController = new CadastrarNovaSenhaController();
		}

		[Test]
		public void IndexTest()
		{

			var result = _cadastroController.Index(It.IsAny<string>(),It.IsAny<string>()) as ViewResult;
			Assert.AreEqual("Index", result.ViewName);
		}
	}
}

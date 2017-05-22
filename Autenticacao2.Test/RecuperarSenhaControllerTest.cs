using System.Web.Mvc;
using Autenticacao2.Controllers;
using NUnit.Framework;

namespace Autenticacao2.Test
{
    [TestFixture]
	public class RecuperarSenhaControllerTest
	{
		private RecuperarSenhaController _recuperarSenhaController;

		[SetUp]
		public void Setup()
		{
			_recuperarSenhaController = new RecuperarSenhaController();
		}

		[Test]
		public void RecuperarTest()
		{

			var result = _recuperarSenhaController.Index() as ViewResult;
			Assert.AreEqual("Index", result.ViewName);
		}
	}
}

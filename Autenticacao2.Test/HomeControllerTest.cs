using System.Web.Mvc;
using Autenticacao2.Controllers;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class HomeControllerTest
	{
		private CadastroNovaSenhaController _homeController;

		[SetUp]
		public void Setup()
		{
			_homeController = new CadastroNovaSenhaController();
		}
		

		[Test]
		public void HomeTest()
		{

			var result = _homeController.Index() as ViewResult;
			Assert.AreEqual("Index", result.ViewName);
		}
	}
}

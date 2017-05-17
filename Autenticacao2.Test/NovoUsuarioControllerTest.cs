using System.Web.Mvc;
using Autenticacao2.Controllers;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class NovoUsuarioControllerTest
	{
		private NovoUsuarioController _novoUsuarioController;

		[SetUp]
		public void Setup()
		{
			_novoUsuarioController = new NovoUsuarioController();
		}


		[Test]
		public void HomeTest()
		{

			var result = _novoUsuarioController.Index() as ViewResult;
			Assert.AreEqual("Index", result.ViewName);
		}
	}
}
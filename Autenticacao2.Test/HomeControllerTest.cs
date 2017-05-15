using System.Web.Mvc;
using Autenticacao2.Controllers;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class HomeControllerTest
	{
		private HomeController _homeController;

		[SetUp]
		public void Setup()
		{
			_homeController = new HomeController();
		}
		

		[Test]
		public void HomeTest()
		{

			var result = _homeController.Index() as ViewResult;
			Assert.AreEqual("Index", result.ViewName);
		}
	}
}

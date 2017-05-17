using System.Web.Mvc;
using Autenticacao2.Controllers;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class LogonControllerTest
	{
		private LogonController _logonController;

		[SetUp]
		public void Setup()
		{
			_logonController = new LogonController();
		}


		[Test]
		public void HomeTest()
		{

			var result = _logonController.Index() as ViewResult;
			Assert.AreEqual("Index", result.ViewName);
		}
	}
}
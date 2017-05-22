using System;
using System.Web.Mvc;
using Autenticacao2.Controllers;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class PerfilControllerTest
	{
		private PerfilController _perfilController;

		[SetUp]
		public void Setup()
		{
			_perfilController = new PerfilController();
		}

		[Test]
		public void HomeTest()
		{
			var id = new Guid();
			var result = _perfilController.Index(id) as ViewResult;
			Assert.AreEqual("Index", result.ViewName);
		}
	}
}
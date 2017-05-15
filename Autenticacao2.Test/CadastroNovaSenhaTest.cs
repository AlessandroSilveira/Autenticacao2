using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autenticacao2.Controllers;
using Moq;
using NUnit.Framework;

namespace Autenticacao2.Test
{
	[TestFixture]
	public class CadastroNovaSenhaTest
	{
		private CadastrarNovaSenhaController _cadastrarNovaSenhaController;
		private HttpContextBase rmContext;
		private HttpRequestBase rmRequest;
		private Mock<HttpContextBase> moqContext;
		private Mock<HttpRequestBase> moqRequest;
		private NameValueCollection formValues;
		[SetUp]
		public void Setup()
		{
			_cadastrarNovaSenhaController = new CadastrarNovaSenhaController();
			moqContext = new Mock<HttpContextBase>();
			moqRequest = new Mock<HttpRequestBase>();
			moqContext.Setup(x => x.Request).Returns(moqRequest.Object);
			formValues = new NameValueCollection
			{
				{ "token", "token" },
				{ "id", "id" }
			};
		}


		//[Test]
		//public void RecuperarTest()
		//{

		//	moqRequest.Setup(r => r.QueryString).Returns(formValues);
		//	// Act
		//	var queryString = moqContext.Object.Request.QueryString;
		//	// Assert
		//	Assert.IsNotNull(queryString);
		//	Assert.AreEqual("token", queryString["token"]);
		//	Assert.AreEqual("id", queryString["id"]);

		//	var result = _cadastrarNovaSenhaController.Index() as ViewResult;
		//	Assert.AreEqual("Index", result.ViewName);
		//}
	}
}

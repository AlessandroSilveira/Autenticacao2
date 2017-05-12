using System.Web.Mvc;

namespace Autenticacao2.Controllers
{
	public class CadastrarNovaSenhaController : Controller
    {
		
        public ActionResult Index()
		{
			ViewBag.token = Request.QueryString["token"];
			ViewBag.id = Request.QueryString["id"];
			return View();
        }
    }
}
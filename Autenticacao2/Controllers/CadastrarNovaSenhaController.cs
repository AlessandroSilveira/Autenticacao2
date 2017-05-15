using System.Web.Http;
using System.Web.Mvc;

namespace Autenticacao2.Controllers
{
	public class CadastrarNovaSenhaController : Controller
    {
        public ActionResult Index([FromUri] string token, [FromUri]string id)
        {
	        ViewBag.token = token;
	        ViewBag.id = id;
			return View("Index");
        }
    }
}
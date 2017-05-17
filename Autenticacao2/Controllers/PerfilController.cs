using System;
using System.Web.Mvc;

namespace Autenticacao2.Controllers
{
    public class PerfilController : Controller
    {
	    public ActionResult Index(Guid id)
	    {
		    ViewBag.id = id;
		    return View("Index");
	    }
    }
}

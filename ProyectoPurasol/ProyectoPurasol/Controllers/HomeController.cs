using System.Web.Mvc;
using BLL;

namespace ProyectoPurasol.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AnotherLink()
        {
            return View("Index");
        }
        [CustomAuthorize]
        public ActionResult Blank()
        {
            return View("Index");
        }
    }
}

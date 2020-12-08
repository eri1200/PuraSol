using BLL;
using System.Web.Mvc;

namespace ProyectoPurasol.Controllers
{
    public class ErrorController : Controller
    {
        [CustomAuthorize]
        [HttpGet]
        public ActionResult InternalServerError()
        {
            return View();
        }

        [CustomAuthorize]
        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}

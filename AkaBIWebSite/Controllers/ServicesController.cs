using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class ServicesController : Controller
    {
        public ActionResult BiServices()
        {
            return View();
        }

        public ActionResult DevelopmentServices()
        {
            return View();
        }
    }
}
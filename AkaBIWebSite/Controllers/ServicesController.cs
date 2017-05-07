using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class ServicesController : Controller
    {
        public ActionResult BiServices()
        {
            ViewBag.Title = "AkaBI | Business Intelligence";
            return View();
        }

        public ActionResult DevelopmentServices()
        {
            ViewBag.Title = "AkaBI | Business Innovation";
            return View();
        }
    }
}
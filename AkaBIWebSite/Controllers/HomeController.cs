using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "AkaBI S.a.rl | Home";
            return View();
        }

        public ActionResult Header()
        {
            return PartialView("_Header");
        }

        public ActionResult Footer()
        {
            return PartialView("_Footer");
        }
    }
}
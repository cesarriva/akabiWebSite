using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class OurCompanyController : Controller
    {
        // GET: OurCompany
        public ActionResult Index()
        {
            ViewBag.Title = "AkaBI S.a.rl | Our Company";
            return View();
        }
    }
}
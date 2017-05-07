using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class OurCompanyController : Controller
    {
        // GET: OurCompany
        public ActionResult Index()
        {
            ViewBag.Title = "AkaBI | Our Company";
            return View();
        }
    }
}
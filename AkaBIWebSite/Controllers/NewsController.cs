using AkaBIWebSite.Contracts.Interfaces;
using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class NewsController : Controller
    {
        private readonly ISocialApiService _socialApiService;

        public NewsController(ISocialApiService socialApiService)
        {
            _socialApiService = socialApiService;
        }

        public ActionResult Index()
        {
            var posts = _socialApiService.GetFacebookPostsForPage();
            
            /*Convert to a view model with:
             */

            return View();
        }
    }
}
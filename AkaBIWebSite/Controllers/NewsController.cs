using AkaBIWebSite.Contracts.Interfaces;
using AkaBIWebSite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class NewsController : BaseController
    {
        private readonly ISocialApiService _socialApiService;

        public NewsController(ISocialApiService socialApiService)
        {
            _socialApiService = socialApiService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "AkaBI | News";
            var posts = _socialApiService.GetFacebookPostsForPage();

            var viewModel = Mapper.Map<NewsPageViewModel>(posts);

            viewModel.ListOfPosts = viewModel.ListOfPosts.Take(6).ToList();
            viewModel.SideBarLastPosts = viewModel.SideBarLastPosts.Take(3).ToList();

            var topPopularPostsDto = _socialApiService.GetFacebookTopPopularPosts(posts.FacebookPosts, 3);
            viewModel.SideBarPopularPosts = Mapper.Map<List<PreviewPostSideBarViewModel>>(topPopularPostsDto);
            
            return View(viewModel);
        }

        public ActionResult PostDetails(string id)
        {
            var post = _socialApiService.GetFacebookPostById(id);

            var viewModel = Mapper.Map<FullPostViewModel>(post);

            return View(viewModel);
        }


    }
}
using AkaBIWebSite.Contracts.Dtos;
using AkaBIWebSite.Contracts.Interfaces;
using AkaBIWebSite.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class NewsController : BaseController
    {
        private readonly ISocialApiService _socialApiService;

        public static Uri PreviousPageUri;
        public static Uri NextPageUri;
        public static int ActualPage;

        public NewsController(ISocialApiService socialApiService)
        {
            _socialApiService = socialApiService;
        }

        public ActionResult Index()
        {
            PreviousPageUri = null;
            NextPageUri = null;
            ActualPage = 1;

            ViewBag.Title = "AkaBI | News";

            var viewModel = GetPosts(null);

            return View(viewModel);
        }

        public ActionResult PreviousPage()
        {
            if (ActualPage == 1)
            {
                ActualPage = 1;
                RedirectToAction("Index");
            }

            ActualPage--;

            var viewModel = GetPosts(PreviousPageUri);

            return View("Index", viewModel);
        }

        public ActionResult NextPage()
        {
            ActualPage++;

            var viewModel = GetPosts(NextPageUri);

            return View("Index", viewModel);
        }

        public ActionResult PostDetails(string id)
        {
            var post = _socialApiService.GetFacebookPostById(id);

            var viewModel = Mapper.Map<FullPostViewModel>(post);

            return View(viewModel);
        }

        private NewsPageViewModel GetPosts(Uri pageUrl)
        {
            FacebookPagePostsDto posts = null;

            if (pageUrl == null)
                posts = _socialApiService.GetInitialFacebookPosts();
            else
                posts = _socialApiService.GetInitialFacebookPosts(pageUrl);

            var viewModel = Mapper.Map<NewsPageViewModel>(posts);

            viewModel.SideBarPopularPosts = Mapper.Map<List<PreviewPostSideBarViewModel>>(_socialApiService.GetFacebookTopPopularPosts(3));
            viewModel.SideBarLastPosts = Mapper.Map<List<PreviewPostSideBarViewModel>>(_socialApiService.GetFacebookLastPosts(3));
            viewModel.PagingSettings.ActualPage = ActualPage;

            PreviousPageUri = viewModel.PagingSettings.PreviusPostsUrl;
            NextPageUri = viewModel.PagingSettings.NextPostsUrl;

            return viewModel;
        }
    }
}
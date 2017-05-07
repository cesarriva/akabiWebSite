using AkaBIWebSite.Contracts.Interfaces;
using AkaBIWebSite.Contracts.Dtos;
using Facebook;
using AkaBIWebSite.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AkaBIWebSite.Services
{
    public class SocialApiService : ISocialApiService
    {
        #region Private

        private FacebookClient fbClient;

        private string GetFacebookAccessToken()
        {
            dynamic result = fbClient.Get(Constants.FacebookAccessTokenUrl, new
            {
                client_id = ConfigSettingsHandler.ReadSetting(Constants.FacebookClientIdKey),
                client_secret = ConfigSettingsHandler.ReadSetting(Constants.FacebookClientSecretKey),
                grant_type = "client_credentials"
            });

            return result.access_token;
        }

        #endregion

        #region Constructor

        public SocialApiService()
        {
            fbClient = new FacebookClient();
            fbClient.Version = "v2.9";
            fbClient.AccessToken = GetFacebookAccessToken();
        }

        #endregion

        #region Interface Implementations

        public FacebookPagePostsDto GetInitialFacebookPosts()
        {
            var url = string.Format(Constants.GetAllPagePostsUrlFormat, ConfigSettingsHandler.ReadSetting(Constants.FacebookPageIdKey));
            var result = GetFacebookResult(url);
            return result;
        }

        public FacebookPagePostsDto GetInitialFacebookPosts(Uri pageUrl)
        {
            var result = GetFacebookResult(pageUrl.ToString().Substring(31));
            return result;
        }

        private FacebookPagePostsDto GetFacebookResult(string url)
        {
            var jsonData = fbClient.Get(url).ToString();
            return JsonConvert.DeserializeObject<FacebookPagePostsDto>(jsonData);
        }

        public FacebookSocialPostDto GetFacebookPostById(string postId)
        {
            var url = string.Format(Constants.GetPostByIdUrlFormat, postId);
            var jsonData = fbClient.Get(url).ToString();

            var result = JsonConvert.DeserializeObject<FacebookSocialPostDto>(jsonData);

            return result;
        }

        public List<FacebookSocialPostDto> GetFacebookTopPopularPosts(int quantity)
        {
            var posts = GetInitialFacebookPosts().FacebookPosts;

            var orderedByPopulatiry = posts.OrderByDescending(x => x.FacebookLikes != null ? x.FacebookLikes.Likes.Count : 0)
                                           .OrderByDescending(x => x.FacebookShares != null ? x.FacebookShares.Count : 0).ToList();

            var result = orderedByPopulatiry.Take(quantity).ToList();
            return result; 
        }

        public List<FacebookSocialPostDto> GetFacebookLastPosts(int quantity)
        {
            var posts = GetInitialFacebookPosts().FacebookPosts;
            var result = posts.Take(quantity).ToList();
            return result;
        }
        
        #endregion
    }
}

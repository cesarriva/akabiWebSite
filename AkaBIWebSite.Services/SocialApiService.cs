using AkaBIWebSite.Contracts.Interfaces;
using AkaBIWebSite.Contracts.Dtos;
using Facebook;
using AkaBIWebSite.Infrastructure;
using Newtonsoft.Json;

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
            fbClient.AccessToken = GetFacebookAccessToken();
        }

        #endregion

        #region Interface Implementations

        public FacebookPagePostsDto GetFacebookPostsForPage()
        {
            var url = string.Format(Constants.GetAllPagePostsUrlFormat, ConfigSettingsHandler.ReadSetting(Constants.FacebookPageIdKey));
            var jsonData = fbClient.Get(url).ToString();

            var result = JsonConvert.DeserializeObject<FacebookPagePostsDto>(jsonData);

            return result;
        }

        public FacebookSocialPostDto GetFacebookPostById(string postId)
        {
            var url = string.Format(Constants.GetPostByIdUrlFormat, postId);
            var jsonData = fbClient.Get(url).ToString();

            var result = JsonConvert.DeserializeObject<FacebookSocialPostDto>(jsonData);

            return result;
        }

        #endregion
    }
}

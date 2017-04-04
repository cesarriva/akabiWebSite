using AkaBIWebSite.Contracts.Dtos;

namespace AkaBIWebSite.Contracts.Interfaces
{
    public interface ISocialApiService
    {
        FacebookPagePostsDto GetFacebookPostsForPage();

        FacebookSocialPostDto GetFacebookPostById(string postId);
    }
}

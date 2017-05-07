using AkaBIWebSite.Contracts.Dtos;
using System.Collections.Generic;

namespace AkaBIWebSite.Contracts.Interfaces
{
    public interface ISocialApiService
    {
        FacebookPagePostsDto GetFacebookPostsForPage();

        FacebookSocialPostDto GetFacebookPostById(string postId);

        List<FacebookSocialPostDto> GetFacebookTopPopularPosts(List<FacebookSocialPostDto> posts, int quantity);
    }
}

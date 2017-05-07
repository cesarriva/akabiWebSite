using AkaBIWebSite.Contracts.Dtos;
using System;
using System.Collections.Generic;

namespace AkaBIWebSite.Contracts.Interfaces
{
    public interface ISocialApiService
    {
        FacebookPagePostsDto GetInitialFacebookPosts();

        FacebookPagePostsDto GetInitialFacebookPosts(Uri pageUrl);

        FacebookSocialPostDto GetFacebookPostById(string postId);

        List<FacebookSocialPostDto> GetFacebookTopPopularPosts(int quantity);

        List<FacebookSocialPostDto> GetFacebookLastPosts(int quantity);
    }
}

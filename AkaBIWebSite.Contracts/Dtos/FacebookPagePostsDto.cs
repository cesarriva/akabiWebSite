using Newtonsoft.Json;
using System.Collections.Generic;

namespace AkaBIWebSite.Contracts.Dtos
{
    public class FacebookPagePostsDto
    {
        [JsonProperty("data")]
        public List<FacebookSocialPostDto> FacebookPosts { get; set; }

        [JsonProperty("paging")]
        public FacebookPagingDto PagingSettings { get; set; }
    }
}

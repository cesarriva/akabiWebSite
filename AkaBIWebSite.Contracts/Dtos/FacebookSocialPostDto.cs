using Newtonsoft.Json;
using System;

namespace AkaBIWebSite.Contracts.Dtos
{
    public class FacebookSocialPostDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("message")]
        public string PostMessage { get; set; }

        [JsonProperty("full_picture")]
        public Uri FullPictureUrl { get; set; }

        [JsonProperty("picture")]
        public Uri SmallPictureUrl { get; set; }
        
        [JsonProperty("link")]
        public Uri FacebookPostLink { get; set; }

        [JsonProperty("permalink_url")]
        public Uri FacebookFeedPostLink { get; set; }

        [JsonProperty("shares")]
        public FacebookSharesDto FacebookShares { get; set; }

        [JsonProperty("likes")]
        public FacebookLikesDto FacebookLikes { get; set; }
    }
}

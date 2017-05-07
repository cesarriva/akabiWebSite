using Newtonsoft.Json;
using System;

namespace AkaBIWebSite.Contracts.Dtos
{

    
    public class FacebookPagingDto
    {
        [JsonProperty("previous")]
        public Uri PreviusPostsUrl { get; set; }

        [JsonProperty("next")]
        public Uri NextPostsUrl { get; set; }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AkaBIWebSite.Contracts.Dtos
{
    public class FacebookLikesDto
    {
        [JsonProperty("data")]
        public List<ListOfLikes> Likes { get; set; }
    }

    public class ListOfLikes
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
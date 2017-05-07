using System;

namespace AkaBIWebSite.Models
{
    public class FacebookPagingViewModel
    {
        public Uri PreviusPostsUrl { get; set; }

        public Uri NextPostsUrl { get; set; }

        public int ActualPage { get; set; }
    }
}
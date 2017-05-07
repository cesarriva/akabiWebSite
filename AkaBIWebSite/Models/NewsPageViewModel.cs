using System.Collections.Generic;

namespace AkaBIWebSite.Models
{
    public class NewsPageViewModel
    {
        public List<FullPostViewModel> ListOfPosts { get; set; }
        public List<PreviewPostSideBarViewModel> SideBarLastPosts { get; set; }
        public List<PreviewPostSideBarViewModel> SideBarPopularPosts { get; set; }
    }
}
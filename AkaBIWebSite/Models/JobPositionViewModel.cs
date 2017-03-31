using System;

namespace AkaBIWebSite.Models
{
    public class JobPositionViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnIsoFormat
        {
            get
            {
                return string.Concat(CreatedOn.ToString("s"), "Z");
            }
        }

        public Uri ViewUrl { get; set; }

        public Uri ApplyUrl { get; set; }
    }
}
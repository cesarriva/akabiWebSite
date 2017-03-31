using System;

namespace AkaBIWebSite.Contracts.Dtos
{
    public class JobPositionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public Uri ViewUrl { get; set; }
        public Uri ApplyUrl { get; set; }
    }
}

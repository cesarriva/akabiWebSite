using System;
using System.Collections.Generic;

namespace AkaBIWebSite.Models
{
    public class CareerPositionsViewModel
    {
        public List<JobPositionViewModel> Posts { get; set; }
        public Guid CompanyId { get; set; }
    }
}
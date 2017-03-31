using System;
using System.Collections.Generic;

namespace AkaBIWebSite.Contracts.Dtos
{
    public class CareerPositionsDto
    {
        public List<JobPositionDto> Posts { get; set; }
        public Guid CompanyId { get; set; }
    }
}

using AkaBIWebSite.Contracts.Dtos;
using AutoMapper;

namespace AkaBIWebSite.Models.Mappers
{
    public class DtoToViewModelMappingProfile : Profile
    {
        public DtoToViewModelMappingProfile()
        {
            CreateMap<JobPositionDto, JobPositionViewModel>();
            CreateMap<CareerPositionsDto, CareerPositionsViewModel>();
        }
    }
}
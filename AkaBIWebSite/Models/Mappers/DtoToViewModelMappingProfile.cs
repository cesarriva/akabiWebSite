using AkaBIWebSite.Contracts.Dtos;
using AutoMapper;
using System.Linq;

namespace AkaBIWebSite.Models.Mappers
{
    public class DtoToViewModelMappingProfile : Profile
    {
        public DtoToViewModelMappingProfile()
        {
            CreateMap<JobPositionDto, JobPositionViewModel>();
            CreateMap<CareerPositionsDto, CareerPositionsViewModel>();

            CreateMap<FacebookSocialPostDto, FullPostViewModel>();
            CreateMap<FacebookSocialPostDto, PreviewPostSideBarViewModel>();

            CreateMap<FacebookPagePostsDto, NewsPageViewModel>()
                .ForMember(dest => dest.ListOfPosts, opt => opt.MapFrom(src => src.FacebookPosts))
                .ForMember(dest => dest.SideBarLastPosts, opt => opt.MapFrom(src => src.FacebookPosts.Take(3).ToList()));
        }
    }
}
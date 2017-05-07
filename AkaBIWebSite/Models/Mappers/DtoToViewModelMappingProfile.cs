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

            CreateMap<FacebookSocialPostDto, FullPostViewModel>();
            CreateMap<FacebookSocialPostDto, PreviewPostSideBarViewModel>();

            CreateMap<FacebookPagingDto, FacebookPagingViewModel>();

            CreateMap<FacebookPagePostsDto, NewsPageViewModel>()
                .ForMember(dest => dest.ListOfPosts, opt => opt.MapFrom(src => src.FacebookPosts));
        }
    }
}
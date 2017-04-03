using AkaBIWebSite.Contracts.Dtos;
using AutoMapper;

namespace AkaBIWebSite.Models.Mappers
{
    public class ViewModelToDtoMappingProfile : Profile
    {
        public ViewModelToDtoMappingProfile()
        {
            CreateMap<ContactFormViewModel, ContactMessageDto>();

            CreateMap<SpontaneousApplyViewModel, SpontaneousApplyDto>()
                .ForMember(dest => dest.CvStream, opt => opt.MapFrom(src => src.Cv.InputStream))
                .ForMember(dest => dest.CvMimeType, opt => opt.MapFrom(src => src.Cv.ContentType))
                .ForMember(dest => dest.CvFileName, opt => opt.MapFrom(src => src.Cv.FileName))
                .ForMember(dest => dest.CoverLetterStream, opt => opt.MapFrom(src => src.CoverLetter.InputStream))
                .ForMember(dest => dest.CoverLetterMimeType, opt => opt.MapFrom(src => src.CoverLetter.ContentType))
                .ForMember(dest => dest.CoverLetterFileName, opt => opt.MapFrom(src => src.CoverLetter.FileName));
        }
    }
}
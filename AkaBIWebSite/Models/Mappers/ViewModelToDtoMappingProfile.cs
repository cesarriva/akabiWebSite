using AkaBIWebSite.Contracts.Dtos;
using AutoMapper;

namespace AkaBIWebSite.Models.Mappers
{
    public class ViewModelToDtoMappingProfile : Profile
    {
        public ViewModelToDtoMappingProfile()
        {
            CreateMap<ContactFormViewModel, ContactMessageDto>();
        }
    }
}
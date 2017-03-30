using AutoMapper;

namespace AkaBIWebSite.Models.Mappers
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ViewModelToDtoMappingProfile>();
            });

            return config;
        }
    }
}
using AutoMapper;
using TravelHelper.Core.Domain;
using TravelHelper.Infrastructure.DTO;

namespace TravelHelper.Infrastructure.Mappers
{
    public  static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new  MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
    }
}

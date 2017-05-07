using AutoMapper;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccountDTO>();
            })
            .CreateMapper();
    }
}
using AutoMapper;
using Core.Domain;
using Infrastrkture.DTO;
using Infrastructure.DTO;

namespace Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account, AccountDTO>();
                cfg.CreateMap<MealDay, MealDayDTO>();
            })
            .CreateMapper();
    }
}
using BettingApp.Domain.DTO;
using BettingApp.Domain.Models;
using Mapster;

namespace BettingApp.Api.Config
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<User, UserDTO>.NewConfig();
            TypeAdapterConfig<UserDTO, User>.NewConfig()
                .Ignore(dest => dest.PasswordHash);
        }
    }
}

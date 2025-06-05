using System.Data;
using BettingApp.Application.Services;
using BettingApp.Domain.Interfaces.InfraServices;
using BettingApp.Infrastructure.InfraServices;
using BettingApp.Domain.Interfaces.Repositories;
using BettingApp.Domain.Interfaces.Services;
using BettingApp.Infrastructure.Repositories;
using Npgsql;

namespace BettingApp.Api.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddBetAppDependencies(this IServiceCollection services, string? connectionString)
        {
            services.AddTransient<IDbConnection>(_ => new NpgsqlConnection(connectionString));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IBetRepository, BetRepository>();
            services.AddTransient<IBetService, BetService>();
            services.AddTransient<IPasswordHasher, BcryptPasswordHasher>();
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
    }
}

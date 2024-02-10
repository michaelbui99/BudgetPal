using Application.V1.CreateAccount.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.V1.CreateAccount;

public static class ServiceExtension
{
    public static IServiceCollection AddCreateAccountServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, EfUserRepository>();
        services.AddScoped<IAccountsRepository, EfAccountsRepository>();
        return services;
    }
}
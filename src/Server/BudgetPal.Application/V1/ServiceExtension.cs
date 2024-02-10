using Application.V1.CreateAccount;
using Application.V1.CreateUser;
using Microsoft.Extensions.DependencyInjection;

namespace Application.V1;

public static class ServiceExtension
{
    public static IServiceCollection AddV1Services(this IServiceCollection services)
    {
        services.AddCreateUserServices();
        services.AddCreateAccountServices();
        return services;
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace Application.V1.CreateAccount;

public static class ServiceExtension
{
    public static IServiceCollection AddCreateAccountServices(this IServiceCollection services)
    {
        return services;
    }
}
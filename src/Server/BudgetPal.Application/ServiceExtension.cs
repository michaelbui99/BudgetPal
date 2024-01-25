using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}
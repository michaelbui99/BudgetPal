using Microsoft.Extensions.DependencyInjection;

namespace Application.V1;

public static class ServiceExtension
{
    public static IServiceCollection AddV1Services(this IServiceCollection services)
    {
        return services;
    }
}
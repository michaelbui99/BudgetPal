using Application.V1.CreateUser.Repositories;
using Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.V1;

public static class ServiceExtension
{
    public static IServiceCollection AddV1Services(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserRepository, EfCreateUserRepository>();
        return services;
    }
}
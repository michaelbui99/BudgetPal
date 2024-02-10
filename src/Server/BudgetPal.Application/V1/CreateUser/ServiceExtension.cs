using Application.V1.CreateUser.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application.V1.CreateUser;

public static class ServiceExtension
{
    public static IServiceCollection AddCreateUserServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserRepository, EfCreateUserRepository>();
        return services;
    }
}
using BudgetPal.Infrastructure.Authentication;
using BudgetPal.Infrastructure.Data;
using Core.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPal.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<BudgetPalContext>();
        services.AddScoped<ISaltService, RandomSaltService>();
        services.AddScoped<IHashingService, Pbkdf2HashingService>();
        services.AddScoped<IAuthenticationService, JwtAuthenticationService>();
        return services;
    }
}
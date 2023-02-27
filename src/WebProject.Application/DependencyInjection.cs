using Microsoft.Extensions.DependencyInjection;
using WebProject.Application.Services.Authentication;

namespace WebProject.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}

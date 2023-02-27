using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WebProject.Application.Common.Interfaces.Authentication;
using WebProject.Application.Common.Interfaces.Services;
using WebProject.Infrastructure.Authentication;
using WebProject.Infrastructure.Services;
using WebProject.Application.Common.Interfaces.Persistence;
using WebProject.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using WebProject.Domain.UserAggregate;

namespace WebProject.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IMigrationsHelper, MigrationsHelper>();
        services.AddScoped<IRepository<User>, Repository<User>>();
        return services;
    }
}

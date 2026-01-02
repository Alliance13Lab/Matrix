using Matrix.Domain.Entities;
using Matrix.Domain.Interfaces;
using Matrix.Infrastructure.Data;
using Matrix.Infrastructure.Repositories;

namespace Matrix.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            options.UseOpenIddict();
        });

        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<INavigationRepository, NavigationRepository>();

        return services;
    }
}
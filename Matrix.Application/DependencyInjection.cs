using Matrix.Application.Interfaces;
using Matrix.Application.Services;

namespace Matrix.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IUserService, UserService>();

        // AutoMapper
        services.AddMapster();
        //services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        //services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
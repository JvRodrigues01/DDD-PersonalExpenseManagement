using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PEM.Application.Services;
using PEM.Domain.Entities;

namespace PEM.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<JwtTokenService>();

            return services;
        }
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(ApplicationModule)));

            return services;
        }
    }
}

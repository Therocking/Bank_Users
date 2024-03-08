using Microsoft.Extensions.DependencyInjection;
using Users.App.Interfaces;
using Users.App.Services;

namespace Users.App
{
    public static class IoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserServices, UsersService>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Users.Infra.Repositories.Interfaces;
using Users.Infra.Repositories;

namespace Users.Infra
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}

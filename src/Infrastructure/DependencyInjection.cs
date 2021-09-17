using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<ProtocolGeneratorDbContext>(options => 
                options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString), b=> b.MigrationsAssembly("WebUi"))
            );
            services.AddScoped<IUserRepository,UserRepository>();
            return services;
        }
    }
}
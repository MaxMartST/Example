using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Example.Domain.UserModel;
using Example.Infrastructure.Data.UserModel;

namespace Example.Infrastructure.Data
{
    public static class DataBindings
    {
        public static IServiceCollection AddRepositories( this IServiceCollection services )
        {
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddDatabase<T>( this IServiceCollection services, string connectionString )
            where T : DbContext
        {
            return services.AddDbContext<T>( c =>
            {
                try
                {
                    c.UseLazyLoadingProxies().UseSqlServer( connectionString );
                }
                catch ( Exception )
                {
                    //TODO: logger
                }
            } );
        }
    }
}

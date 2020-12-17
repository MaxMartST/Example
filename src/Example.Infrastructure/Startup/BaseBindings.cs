using Microsoft.Extensions.DependencyInjection;
using Example.Infrastructure.Clock;
using Example.Infrastructure.Data;
using Example.Infrastructure.ServiceScope;
using Example.Infrastructure.UoW;

namespace Example.Infrastructure.Startup
{
    public static class BaseBindings
    {
        public static IServiceCollection AddBaseServices( this IServiceCollection services )
        {
            return services
                .AddClock()
                .AddRepositories()
                .AddUnitOfWork()
                .AddTransient( typeof( IServiceScopeWrapper ), typeof( ServiceScopeWrapper ) );
        }
    }
}

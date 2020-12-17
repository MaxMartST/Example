using Microsoft.Extensions.DependencyInjection;

namespace Example.Domain
{
    public static class DomainBindings
    {
        public static IServiceCollection AddDomain( this IServiceCollection services )
        {
            return services;
        }
    }
}

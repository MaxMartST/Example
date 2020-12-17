using Example.Application.Calculator;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Application
{
    public static class ApplicationBindings
    {
        public static IServiceCollection AddApplication( this IServiceCollection services )
        {
            services.AddScoped<ICalculator, Calculator.Calculator>();
            return services;
        }
    }
}

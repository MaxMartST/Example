using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Example.Infrastructure.Web
{
    public static class AddDefaultMvcExtension
    {
        public static IMvcBuilder AddDefaultMvc( this IServiceCollection services, string addApplicationPart )
        {
            return services.AddControllers()
                .AddNewtonsoftJson(
                    options =>
                    {
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    })
                .AddApplicationPart(Assembly.Load(new AssemblyName(addApplicationPart)));
        }
    }
}

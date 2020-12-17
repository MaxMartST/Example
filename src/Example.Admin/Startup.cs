using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Example.Infrastructure.Startup;
using Microsoft.AspNetCore.Hosting;

namespace Example.Admin
{
    public class Startup : IBaseStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            AddServices(services);

            return services.BuildServiceProvider();
        }

        public void AddServices(IServiceCollection services)
        {
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
        }

        public virtual void Configure(IApplicationBuilder app)
        {

            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();

            app.UseDeveloperExceptionPageIfDev();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
    }
}

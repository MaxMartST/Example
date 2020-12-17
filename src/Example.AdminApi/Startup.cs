using System;
using Autofac;
using AutoMapper;
using Example.Application;
using Example.Infrastructure.Data;
using Example.Infrastructure.Startup;
using Example.Infrastructure.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Example.AdminApi
{
    public class Startup : IBaseStartup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            AddServices(services);

            return services.BuildServiceProvider();
        }

        public virtual void AddServices(IServiceCollection services)
        {
            ConfigureDatabase(services);

            services.AddFeatureManagement();
            services.AddHealthChecks();
            services.AddRazorPages();
            services.AddAutoMapper(typeof(Startup));

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services
                .AddBaseServices()
                .AddApplicationInsightsTelemetry()
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddControllersWithViews();
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
           {
               endpoints.MapRazorPages();
               endpoints.MapHealthChecks("/health");
           });
        }

        public virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDatabase<ExampleContext>(Configuration.GetConnectionString("ExampleConnection"));
        }
    }
}

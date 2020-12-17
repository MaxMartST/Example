using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Example.AdminApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().RunAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            //var config = new ConfigurationBuilder().AddCommandLine( args ).Build();
            return new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder
                        //.UseConfiguration( config )
                        .UseKestrel()
                        .UseStartup<Startup>();
                });
        }
    }
}

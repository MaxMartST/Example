using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Infrastructure.Startup
{
    public interface IBaseStartup : IStartup
    {
        void AddServices( IServiceCollection services );
    }
}

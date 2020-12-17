using System;
using System.Threading.Tasks;

namespace Example.Infrastructure.ServiceScope
{
    public interface IServiceScopeWrapper
    {
        Task InvokeAction( Func<IServiceProvider, Task> action );
    }
}

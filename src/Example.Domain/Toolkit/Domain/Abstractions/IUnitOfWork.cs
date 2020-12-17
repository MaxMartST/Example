using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Domain.Toolkit.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync( string traceId = null, CancellationToken cancellationToken = default(CancellationToken) );
    }
}
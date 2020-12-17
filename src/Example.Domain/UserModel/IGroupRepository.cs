using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Domain.Toolkit.Domain.Abstractions;

namespace Example.Domain.UserModel
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<List<Group>> GetAll();
        
        Task AddGroup( Group group );
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Domain.Toolkit.Domain.Abstractions;

namespace Example.Domain.UserModel
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAll();
        Task<User> GetByUsername( string username );
        Task AddUser( User user );
        Task UpdateUser( User user );
    }
}

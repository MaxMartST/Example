using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example.AdminApi.Dto;
using Example.AdminApi.Mappers;
using Example.Domain.UserModel;

namespace Example.AdminApi.Controllers
{
    [ApiVersion( "1.0" )]
    [Route( "v{version:apiVersion}/users" )]
    [Produces( "application/json" )]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<List<UserDto>> ListAll()
        {
            List<User> users = await _userRepository.GetAll();
            return users.Map();
        }
    }
}

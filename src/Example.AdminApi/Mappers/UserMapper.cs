using System.Collections.Generic;
using System.Linq;
using Example.AdminApi.Dto;
using Example.Domain.UserModel;

namespace Example.AdminApi.Mappers
{
    public static class UserMapper
    {
        public static UserDto Map( this User user )
        {
            if ( user == null )
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
            };
        }

        public static List<UserDto> Map( this IEnumerable<User> users )
        {
            return users == null ? new List<UserDto>() : users.ToList().ConvertAll( Map );
        }

    }
}

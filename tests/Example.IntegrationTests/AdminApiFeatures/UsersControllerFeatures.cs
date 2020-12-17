using System.Collections.Generic;
using System.Threading.Tasks;
using Example.AdminApi.Dto;
using Example.Domain.UserModel;
using Example.IntegrationTests.ObjectMothers;
using Example.IntegrationTests.StepDefinitions;
using NUnit.Framework;

namespace Example.IntegrationTests.AdminApiFeatures
{
    public class UsersControllerFeatures : AdminApiFeature
    {
        [Test]
        public async Task GetUsers_Scenario()
        {
            // Given
            User user = await Runner.GivenICreateUser( Users.UserVasya );

            // When


            // Then
            await Runner.ThenIHaveUsersFromApi( new List<UserDto>
            {
                new UserDto
                {
                    Id = user.Id,
                    Username = user.Username
                }
            } );
        }
    }
}

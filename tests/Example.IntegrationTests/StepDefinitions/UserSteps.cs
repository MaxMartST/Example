using System.Collections.Generic;
using System.Threading.Tasks;
using Example.AdminApi.Dto;
using Example.Domain.Toolkit.Domain.Abstractions;
using Example.Domain.UserModel;
using Example.IntegrationTests.ObjectMothers;
using Example.IntegrationTests.TestKit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Example.IntegrationTests.StepDefinitions
{
    public static class ClientSteps
    {
        public static async Task<User> GivenICreateUser(
            this ITestRunner testRunner,
            Users.MotherObject userMotherObject )
        {
            return await testRunner.GivenICreateUser( userMotherObject.Username );
        }

        public static async Task<User> GivenICreateUser(
            this ITestRunner testRunner,
            string username )
        {
            using ( IServiceScope scope = testRunner.Driver.Services().CreateScope() )
            {
                IUserRepository userRepository = scope.ServiceProvider.GetService<IUserRepository>();
                IUnitOfWork unitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>();

                User user = new User( username );
                await userRepository.AddUser( user );
                await unitOfWork.SaveEntitiesAsync();

                return user;
            }
        }

        public static async Task ThenIHaveUsersFromApi(
            this ITestRunner testRunner,
            List<UserDto> expectedDto )
        {
            List<UserDto> actualDto = await testRunner.Driver.HttpClientGetAsync<List<UserDto>>( $"v1/users" );

            actualDto.Should().BeEquivalentTo( expectedDto );
        }
    }
}

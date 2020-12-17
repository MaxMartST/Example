using System.Threading.Tasks;

namespace Example.IntegrationTests.TestKit
{
    public interface IDbSeeder
    {
        Task Seed();
    }
}

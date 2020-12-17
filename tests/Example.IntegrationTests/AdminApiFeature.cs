using Example.IntegrationTests.TestKit;

namespace Example.IntegrationTests
{
    public class AdminApiFeature : TestFeature
    {
        protected override void SetUp()
        {
            Driver = new TestDriver( typeof( AdminApiStartup ) );
            Runner = new TestRunner( Driver );
            Driver.SeedDatabase();
        }

        protected override void TearDown()
        {
        }
    }
}

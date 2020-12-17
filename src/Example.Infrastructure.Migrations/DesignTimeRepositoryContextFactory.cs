using Example.Infrastructure.Clock;
using Example.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Example.Infrastructure.Migrations
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<ExampleContext>
    {
        private readonly IClock _clock;

        public DesignTimeRepositoryContextFactory( IClock clock )
        {
            _clock = clock;
        }

        public DesignTimeRepositoryContextFactory()
        {
        }

        public ExampleContext CreateDbContext( string[] args )
        {
            IConfiguration config = MigrationExtension.GetConfig();
            var connectionString = config.GetConnectionString( "ExampleConnection" );
            var optionsBuilder = new DbContextOptionsBuilder<ExampleContext>();
            optionsBuilder.UseSqlServer( connectionString,
                x => x.MigrationsAssembly( "Example.Infrastructure.Migrations" ) );
            return new ExampleContext( optionsBuilder.Options, _clock );
        }
    }
}

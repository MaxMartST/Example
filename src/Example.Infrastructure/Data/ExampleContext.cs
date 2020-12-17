using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Example.Domain.UserModel;
using Example.Infrastructure.Data.UserModel.EntityConfigurations;
using Example.Domain.Toolkit.Domain.Abstractions;
using Example.Infrastructure.Clock;

namespace Example.Infrastructure.Data
{
    public class ExampleContext : DbContext, IUnitOfWork
    {
        private readonly IClock _clock;

        public ExampleContext(
            DbContextOptions<ExampleContext> options,
            IClock clock ) : base( options )

        {
            _clock = clock;
        }

        private ExampleContext( DbContextOptions<ExampleContext> options ) : base( options )
        {
        }


        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }


        protected override void OnModelCreating( ModelBuilder builder )
        {
            base.OnModelCreating( builder );
            
            builder.ApplyConfiguration( new UserMap() );
            builder.ApplyConfiguration( new UserGroupMap() );
            builder.ApplyConfiguration( new GroupMap() );

            foreach ( var property in builder.Model.GetEntityTypes().SelectMany( t => t.GetProperties() ) )
            {
                if ( property.ClrType == typeof( decimal ) || property.ClrType == typeof( decimal? ) )
                {
                    property.Relational().ColumnType = "decimal(19, 4)";
                }
                else if ( property.ClrType == typeof( DateTime ) || property.ClrType == typeof( DateTime? ) )
                {
                    property.SetValueConverter(
                        new ValueConverter<DateTime, DateTime>(
                            v => v,
                            v => DateTime.SpecifyKind( v, DateTimeKind.Utc ) ) );

                    if ( property.ValueGenerated != ValueGenerated.Never )
                    {
                        property.SetValueGeneratorFactory( ( _, __ ) => new DateTimeNowGenerator( _clock ) );
                    }
                }
            }
        }

        public async Task<bool> SaveEntitiesAsync( string traceId = null,
            CancellationToken cancellationToken = default(CancellationToken) )
        {
            await SaveChangesAsync( cancellationToken );

            return true;
        }
    }
}

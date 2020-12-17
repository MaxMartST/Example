using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Example.Domain.UserModel;

namespace Example.Infrastructure.Data.UserModel.EntityConfigurations
{
    public class UserGroupMap : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure( EntityTypeBuilder<UserGroup> builder )
        {
            builder.Ignore( x => x.Id );
            builder.HasKey( x => new { x.UserId, RoleId = x.GroupId } );
        }
    }
}

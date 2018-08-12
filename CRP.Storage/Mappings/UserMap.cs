using CRP.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace CRP.Storage.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(200);
            Property(x => x.UserType).IsRequired();
            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}

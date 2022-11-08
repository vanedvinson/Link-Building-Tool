using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "9a2817b4-8181-437b-afea-ee1daff707b4",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
                //  Type = "extern"


            },
            new IdentityRole
            {
                Id = "488b094c-65cf-43b7-a8e6-d2be36286c6a",
                Name = "Linkbuilder",
                NormalizedName = "LINKBUILDER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
                //  Type = "intern"
            });
        }
    }
}

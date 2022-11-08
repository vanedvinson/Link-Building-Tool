using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(

             new IdentityUserRole<string>
             {
                 UserId = "f05fccf7-dac0-4f24-9c54-92208e06fb01",
                 RoleId = "9a2817b4-8181-437b-afea-ee1daff707b4",

             },
            new IdentityUserRole<string>
            {

                UserId = "584290a6-6e87-43bf-bde1-626c5d993e85",
                RoleId = "488b094c-65cf-43b7-a8e6-d2be36286c6a",

            },
            new IdentityUserRole<string>
            {

                UserId = "c6ada4f0-bdf8-4e34-aa73-05a189e76103",
                RoleId = "488b094c-65cf-43b7-a8e6-d2be36286c6a",

            });
        }
    }
}

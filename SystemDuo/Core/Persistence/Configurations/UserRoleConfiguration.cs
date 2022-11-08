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
           
             new UserRole
             {
                 UserId = "eb963452-683c-40be-8777-97d5a90792a1",
                 RoleId = "578861f8-d0a3-4a8a-81f5-488b37fdf204", 

             },
            new UserRole
            {
                UserId = "eb963452-683c-40be-8777-97d5a90792a1",
                RoleId = "c3d77b2f-6f66-4681-9f54-fc746f48d669",

            });
        }
    }
}

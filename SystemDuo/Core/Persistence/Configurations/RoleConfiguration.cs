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
            new Role
            {
                Id= "9a2817b4-8181-437b-afea-ee1daff707b4",
                Name = "Candidate",
                NormalizedName = "CANDIDATE",
                Type="extern"
                
              
            },

             new Role
             {
                 Id= "578861f8-d0a3-4a8a-81f5-488b37fdf204",
                 Name = "Senior Agent",
                 NormalizedName = "SENIOR AGENT",
                 Type = "intern"
             },
            new Role
            {
                Id= "c3d77b2f-6f66-4681-9f54-fc746f48d669",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Type = "intern"
            },
            new Role
            {
                Id = "488b094c-65cf-43b7-a8e6-d2be36286c6a",
                Name = "Junior Agent",
                NormalizedName = "JUNIOR AGENT",
                Type = "intern"
            });
        }
    }
}

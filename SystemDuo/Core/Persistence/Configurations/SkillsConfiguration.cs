using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class SkillsConfiguration : IEntityTypeConfiguration<Skills>
    {
        public void Configure(EntityTypeBuilder<Skills> builder)
        {
            builder.HasData(
            new Skills
            {
                Id= Guid.NewGuid(),
                Name = "C#"
            },

            new Skills
            {
                Id = Guid.NewGuid(),
                Name = "Java",

            },
            new Skills
            {
                Id =  Guid.NewGuid(),
                Name = "Angular"
            });


        }
    }
}

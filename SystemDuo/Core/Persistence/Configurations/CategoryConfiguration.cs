using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
            new Category
            {
               Id= new Guid("3712a212-2d9a-4253-b62c-77770907003f"),
               Name ="IT",
               CreatedAt=DateTime.UtcNow,
               UpdatedAt=DateTime.UtcNow,
            },
            new Category
             {
                 Id=new Guid("e6e24a2c-0ada-4aa4-8bf7-de37c958dc3c"), 
                 Name = "Medicine",
                 CreatedAt = DateTime.UtcNow,
                 UpdatedAt = DateTime.UtcNow,
                 
            });

        }
    }
}

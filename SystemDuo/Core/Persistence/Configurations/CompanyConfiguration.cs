using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

            builder.HasData(
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Zulke",
                CategoryId = new Guid("3712a212-2d9a-4253-b62c-77770907003f"),
                LongTerm =true,
                LocationId=new Guid("3712a212-2d9a-4253-b62c-77770907003f"),
                DeletedAt = DateTime.UtcNow

            },
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Levi9",
                CategoryId = new Guid("3712a212-2d9a-4253-b62c-77770907003f"),
                LongTerm=true,
                LocationId = new Guid("3712a212-2d9a-4253-b62c-77770907003f"),
                DeletedAt = DateTime.UtcNow

            }) ;

        }
    }
}

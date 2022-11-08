using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
            new Location
            {
                Id = new Guid("3712a212-2d9a-4253-b62c-77770907003f"),
                Country = "Serbia",
                City = "Novi Pazar",
                Address = "Avnoja bb",
                PostalCode = "33600"
            }
            );
           

        }
    }
}

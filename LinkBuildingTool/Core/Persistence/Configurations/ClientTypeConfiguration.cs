using LinkBuildingTool.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LinkBuildingTool.Core.Persistence.Configurations
{
    public class ClientTypeConfiguration : IEntityTypeConfiguration<ClientType>
    {
        public void Configure(EntityTypeBuilder<ClientType> builder)
        {
            builder.HasData(
            new ClientType
            {
                Id = Guid.NewGuid(),
                Name= "Anzahl",
                Amount = 2

            },
            new ClientType
            {
                Id = Guid.NewGuid(),
                Name = "Budget",
                Amount = 200

            });
        }
    }
}

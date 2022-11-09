using LinkBuildingTool.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkBuildingTool.Core.Persistence.Configurations
{
    public class LinkAttributeConfiguration : IEntityTypeConfiguration<LinkAttribute>
    {
        public void Configure(EntityTypeBuilder<LinkAttribute> builder)
        {
            builder.HasData(
            new LinkAttribute
            {
                Id = Guid.NewGuid(),
                Name = "follow"

            },
            new LinkAttribute
            {
                Id = Guid.NewGuid(),
                Name = "nofollow"

            });
        }
    }
}

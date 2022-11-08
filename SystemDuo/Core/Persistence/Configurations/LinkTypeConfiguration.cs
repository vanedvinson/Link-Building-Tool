using SystemDuo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class LinkTypeConfiguration : IEntityTypeConfiguration<LinkType>
    {
        public void Configure(EntityTypeBuilder<LinkType> builder)
        {
            builder.HasData(
            new LinkType
            {
                Id = Guid.NewGuid(),
                Name = "editorial"

            },
            new LinkType
            {
                Id = Guid.NewGuid(),
                Name = "community"

            },
            new LinkType
            {
                Id = Guid.NewGuid(),
                Name = "directory"

            });
        }
    }
}

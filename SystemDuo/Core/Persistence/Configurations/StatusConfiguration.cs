using SystemDuo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "Vorschlag",
                Group = 1

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "1. Kontakt",
                Group = 2

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "2. Kontakt",
                Group = 2

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "3. Kontakt",
                Group = 2

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "Verhandlung",
                Group = 2

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "Zusage",
                Group = 3

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "WM Schreibt",
                Group = 3

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "Text bestellt",
                Group = 3

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "Text verschickt",
                Group = 3

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "Änderung",
                Group = 3

            },
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "Live",
                Group = 3

            });
        }
    }
}

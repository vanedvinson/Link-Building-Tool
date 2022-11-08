using SystemDuo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SystemDuo.Core.Persistence.Configurations
{
    public class DomainConfiguration : IEntityTypeConfiguration<ClientDomain>
    {
        public void Configure(EntityTypeBuilder<ClientDomain> builder)
        {
            builder.HasData(
                new ClientDomain
                {
                    Id = new Guid("326ffb9d-411e-4007-81b1-504a9d865948"),
                    Name="domain 1",
                    Theme = " theme 1"
                },
                new ClientDomain
                {
                    Id = new Guid("42f6e765-0015-43eb-8dc2-ba7483d9bcc4"),
                    Name = "domain 2",
                    Theme = " theme 2"
                });
        }
    }
}

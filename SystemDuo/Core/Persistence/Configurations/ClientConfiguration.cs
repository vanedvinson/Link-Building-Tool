using SystemDuo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(
                new Client
                {
                    Id = new Guid("385786b8-c5f4-4f2a-b6ba-b168702a71db"),
                    Name = "client 1",
                },
                new Client
                {
                    Id = new Guid("8c44ca32-beef-4aa2-a24c-ac3161ac8133"),
                    Name = "client 2",
                });
        }
    }
}

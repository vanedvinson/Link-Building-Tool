using SystemDuo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class WebmasterConfiguration : IEntityTypeConfiguration<Webmaster>
    {
        public void Configure(EntityTypeBuilder<Webmaster> builder)
        {
            builder.HasData(
                new Webmaster
                {
                    Id= new Guid("b5b985c9-5612-43e2-b92e-a3c93b0ef477"),
                    Name="webmaster 1",
                    Lastname="web 1",
                    Phone="123",
                    Email="webm",
                    SocialMediaUrl="https://google.com",
                    Note="good"
                },
                new Webmaster
                {
                    Id = new Guid("5582f8c6-ff31-4710-9076-99ef832e4b66"),
                    Name = "webmaster 2",
                    Lastname = "web 2",
                    Phone = "123",
                    Email = "webm",
                    SocialMediaUrl = "https://google.com",
                    Note = "good"
                },
                new Webmaster
                {
                    Id = new Guid("40eb95a8-b88d-448d-816f-0d100d9d2feb"),
                    Name = "webmaster 3",
                    Lastname = "web 3",
                    Phone = "123",
                    Email = "webm",
                    SocialMediaUrl = "https://google.com",
                    Note = "good"
                });
        }
    }
}

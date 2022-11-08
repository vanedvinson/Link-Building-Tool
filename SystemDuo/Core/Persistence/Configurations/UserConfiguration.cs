using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
        
           builder.HasData(
           new User
           {
               Id= "eb963452-683c-40be-8777-97d5a90792a1",
               UserName = "melidaradoncic@hotmail.com",
               NormalizedUserName = "MELIDARADONCIC@HOTMAIL.COM",
               Email = "melidaradoncic@hotmail.com",
               NormalizedEmail = "MELIDARADONCIC@HOTMAIL.COM",
               FirstName="Melida",
               LastName="Radoncic"
           });

        }
    }
}

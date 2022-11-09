using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            var admin = new User
            {
                Id = "f05fccf7-dac0-4f24-9c54-92208e06fb01",
                FirstName = "Admin",
                LastName = "Admin",
                CreatedAt = DateTime.Now,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "benjamin@an-digital.com",
                NormalizedEmail = "BENJAMIN@AN-DIGITAL.COM",
                EmailConfirmed = true,
                PhoneNumber = "0600103693",
                SecurityStamp = string.Empty
            };

            var user = new User
            {
                Id = "584290a6-6e87-43bf-bde1-626c5d993e85",
                FirstName = "Linkbuilder",
                LastName = "Lb",
                CreatedAt = DateTime.Now,
                UserName = "linkbuilder",
                NormalizedUserName = "LINKBUILDER",
                Email = "milan@an-digital.com",
                NormalizedEmail = "MILAN@AN-DIGITAL.COM",
                EmailConfirmed = true,
                PhoneNumber = "0600103693",
                SecurityStamp = string.Empty
            };

            var user1 = new User
            {
                Id = "c6ada4f0-bdf8-4e34-aa73-05a189e76103",
                FirstName = "Linkbuilder2",
                LastName = "Lb2",
                CreatedAt = DateTime.Now,
                UserName = "linkbuilder2",
                NormalizedUserName = "LINKBUILDER2",
                Email = "e.kovacevic102@gmail.com",
                NormalizedEmail = "E.KOVACEVIC102@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "0600103693",
                // SecurityStamp = string.Empty
            };
            admin.PasswordHash = PassGenerate(admin);
            user.PasswordHash = PassGenerate(user);
            user1.PasswordHash = PassGenerate(user1);

            builder.HasData(admin);
            builder.HasData(user);
            builder.HasData(user1);




        }

        public string PassGenerate(User user)
        {
            var passHash = new PasswordHasher<User>();
            return passHash.HashPassword(user, "2-CsVRkhU4tyPe6");
        }
    }
}

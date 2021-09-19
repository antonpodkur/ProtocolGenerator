using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(s => s.Id).IsRequired(true);
            builder.HasIndex(e => e.Id).IsUnique();
            builder.Property(s => s.Email).IsRequired(true).HasMaxLength(50);
            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(s => s.Password).IsRequired(true).HasMaxLength(255);
            builder.Ignore(s => s.Password);
            
            builder.HasData(
                    new User()
                    {
                        Id = 2,
                        Email = "johndoe@gmail.com",
                        Password = "123456"
                    },
                    new User()
                    {
                        Id = 1,
                        Email = "janedoe@gmail.com",
                        Password = "123456"
                    },
                    new User()
                    {
                        Id = 3,
                        Email = "myemail@gmail.com",
                        Password = "1234567"
                    }
                );
        }
    }
}
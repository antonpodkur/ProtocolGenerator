using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace Infrastructure
{
    public class ProtocolGeneratorDbContext : DbContext
    {
        private string connectionString =
            "server=sql4.freemysqlhosting.net; port=3306; database=sql4437240; user=sql4437240; password=GPKkwnvsnI; Persist Security Info=False; Connect Timeout=300";

        
        public DbSet<User> User { get; set; }
        
        public ProtocolGeneratorDbContext():base() { }

        public ProtocolGeneratorDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(
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
                    }
                );
        }
    }
}
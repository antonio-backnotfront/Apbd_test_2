using AuthTest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthTest.API.DAL;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role()
            {
                Id = 1,
                Name = "Admin",
            }, new Role()
            {
                Id = 2,
                Name = "User"
            }
        );
        modelBuilder.Entity<Account>().HasData(
            new Account()
            {
                Id = 1,
                Username = "anton",
                Password = "pass_anton",
                RoleId = 1
            }, new Account()
            {
                Id = 2,
                Username = "john",
                Password = "pass_john",
                RoleId = 2
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
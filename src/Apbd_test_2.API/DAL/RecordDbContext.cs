using Apbd_test_2.API.Models;
using Microsoft.EntityFrameworkCore;
using Task = Apbd_test_2.API.Models.Task;

namespace Apbd_test_2.API.DAL;

public class RecordDbContext(DbContextOptions<RecordDbContext> options) : DbContext(options)
{
    public DbSet<Language> Languages { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Role>().HasData(
        //     new Role()
        //     {
        //         Id = 1,
        //         Name = "Admin",
        //     }, new Role()
        //     {
        //         Id = 2,
        //         Name = "User"
        //     }
        // );
        // modelBuilder.Entity<Account>().HasData(
        //     new Account()
        //     {
        //         Id = 1,
        //         Username = "anton",
        //         Password = "pass_anton",
        //         RoleId = 1
        //     }, new Account()
        //     {
        //         Id = 2,
        //         Username = "john",
        //         Password = "pass_john",
        //         RoleId = 2
        //     }
        // );

        base.OnModelCreating(modelBuilder);
    }
}
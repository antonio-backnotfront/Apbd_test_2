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
        modelBuilder.Entity<Language>().HasData(
            new Language()
            {
                Id = 1,
                Name = "C++",
            },
            new Language()
            {
                Id = 2,
                Name = "Java",
            },
            new Language()
            {
                Id = 3,
                Name = "C#",
            }
        );
        modelBuilder.Entity<Student>().HasData(
            new Student()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@gmail.com",
            },
            new Student()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@gmail.com",
            },
            new Student()
            {
                Id = 3,
                FirstName = "Marta",
                LastName = "Doe",
                Email = "marta.doe@gmail.com",
            }
        );
        modelBuilder.Entity<Task>().HasData(
            new Task()
            {
                Id = 1,
                Name = "Test",
                Description = "Test preparation",
            },
            new Task()
            {
                Id = 2,
                Name = "Exam",
                Description = "Exam preapration",
            },
            new Task()
            {
                Id = 3,
                Name = "Review",
                Description = "Review preparation",
            }
        );

        modelBuilder.Entity<Record>().HasData(
            new Record()
            {
                Id = 1,
                LanguageId = 1,
                StudentId = 1,
                TaskId = 1,
                CreatedAt = new DateTime(2022,1,1),
                ExecutionTime = 11
            },
            new Record()
            {
                Id = 2,
                LanguageId = 2,
                StudentId = 1,
                TaskId = 2,
                CreatedAt = new DateTime(2019,8,22),
                ExecutionTime = 16
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
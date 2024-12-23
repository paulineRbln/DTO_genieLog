using Microsoft.EntityFrameworkCore;
using ApiUniversity.Models;

public class DBContext : DbContext
{
  public DbSet<Student> Students { get; set; } = null!;
  public DbSet<Course> Courses { get; set; } = null!;
  public DbSet<Enrollment> Enrollments { get; set; } = null!;
  public DbSet<Instructor> Instructors { get; set; } = null!;
  public DbSet<Department> Departments { get; set; } = null!;
  
  public string DbPath { get; private set; }


  public DBContext()
  {
    // Path to SQLite database file
    DbPath = "ApiUniversity.db";
  }


  // The following configures EF to create a SQLite database file locally
  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    // Use SQLite as database
    options.UseSqlite($"Data Source={DbPath}");
    // Optional: log SQL queries to console
    //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
  }
}

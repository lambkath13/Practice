using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository.OtherRepository;

public class RepositoryContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Student> Students { get; set; } = null!;

    public DbSet<Course> Courses { get; set; } = null!;

    public DbSet<Group> Groups { get; set; } = null!;

    public DbSet<StudentGroup> StudentGroups { get; set; } = null!;
}
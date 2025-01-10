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
        modelBuilder.Entity<GroupMentor>()
            .HasKey(gm => new { gm.GroupId, gm.MentorId });
        modelBuilder.Entity<UserPosition>()
            .HasKey(up => new { up.UserId, up.PositionId });
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<User> Students { get; set; } = null!;
    public DbSet<User> Mentors { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<StudentGroup> StudentGroups { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<GroupMentor> GroupMentors { get; set; } = null!;
    public DbSet<Phone> Phones { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<Resource> Resources { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Syllabus> Syllabuses { get; set; } = null!;
    public DbSet<TimeTable> TimeTables { get; set; } = null!;
    public DbSet<UserAccount> UserAccounts { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; } = null!;
    public DbSet<UserPosition> UserPositions { get; set; } = null!;
}
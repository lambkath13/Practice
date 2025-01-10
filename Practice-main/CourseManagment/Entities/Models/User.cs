using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Models;

public class User
{
    public Guid Id { get; set; }

    [MaxLength(250)]
    public required string FirstName { get; set; }
    [MaxLength(250)]
    public required string LastName { get; set; }
    public DateTimeOffset BornDate { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    [MaxLength(50)]
    public string? Email { get; set; } 
    [MaxLength(50)]
    public string? Phone { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset RegisteredAt { get; set; }

    // navigations
    public List<StudentGroup> Group { get; set; } = [];
    public List<UserAccount> Account { get; set; } = [];
    public List<UserRole> Role { get; set; } = [];
    public List<UserPosition> Position { get; set; } = [];

}

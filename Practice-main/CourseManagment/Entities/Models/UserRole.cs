using Entities.Enums;

namespace Entities.Models;

public class UserRole
{
    public Guid RoleId { get; set; }
    public Guid UserId { get; set; }
    public Status Status { get; set; }
    
    //navigation
    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;
}
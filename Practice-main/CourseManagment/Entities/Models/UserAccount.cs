using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Models;

public class UserAccount
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Status Status { get; set; }
    [MaxLength(100)]
    public required string PasswordHash { get; set; }
    
    //navigation
    public User User { get; set; } = null!;
}
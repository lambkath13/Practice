using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Models;

public class UserAccount
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Status Status { get; set; }
    public required string PasswordHash { get; set; }
}
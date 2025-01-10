using Entities.Enums;

namespace Entities.Models;

public class GroupMentor
{
    public Guid GroupId { get; set; }
    public Guid MentorId { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset FinishedAt { get; set; }
    public Status Status { get; set; }
    
    //navigation
    public Group Group { get; set; } = null!;
    public User Mentor { get; set; } = null!;
}
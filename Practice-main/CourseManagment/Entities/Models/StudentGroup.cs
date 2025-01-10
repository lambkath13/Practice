using Entities.Enums;

namespace Entities.Models;

public class StudentGroup
{
    public Guid GroupId { get; set; }
    public Guid UserId { get; set; }
    public StudentGroupStatus Status { get; set; }
    public string? Note { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset? FinishedAt { get; set; }


    // navigations
    public Group Group { get; set; } = null!;
    public User Student { get; set; } = null!;
}

 
using Entities.Enums;

namespace Entities.Models;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset FinishedAt { get; set; }
    public GroupStatus Status { get; set; }
    public Guid CourseId { get; set; }

    // navigations
    public Course Course { get; set; } = null!;
    public List<StudentGroup> Students { get; set; } = [];
}
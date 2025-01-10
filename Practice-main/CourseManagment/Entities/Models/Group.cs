using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Models;

public class Group
{
    public Guid Id { get; set; }
    [MaxLength(250)]
    public string Name { get; set; } = null!;
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset FinishedAt { get; set; }
    public GroupStatus Status { get; set; }
    public Guid CourseId { get; set; }
    public Guid BranchId { get; set; }

    // navigations
    public Course Course { get; set; } = null!;
    public List<StudentGroup> Student { get; set; } = [];
    public List<TimeTable> TimeTable { get; set; } = [];
}
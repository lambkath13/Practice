using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Shared.GroupDto;

public class GroupDto
{
    public Guid Id { get; set; }
    [MaxLength(250)]
    public string Name { get; set; } = null!;
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset FinishedAt { get; set; }
    public GroupStatus Status { get; set; }
    public Guid CourseId { get; set; }
}
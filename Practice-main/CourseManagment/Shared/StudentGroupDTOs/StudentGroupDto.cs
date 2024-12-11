using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Shared.StudentGroupDTOs;

public class StudentGroupDto
{
    public Guid GroupId { get; set; }
    public Guid StudentId { get; set; }
    public StudentGroupStatus Status { get; set; }
    [MaxLength(250)]
    public string? Note { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset? FinishedAt { get; set; }
}
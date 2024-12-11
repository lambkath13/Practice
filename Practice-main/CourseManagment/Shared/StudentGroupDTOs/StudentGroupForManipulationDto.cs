using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Shared.StudentGroupDTOs;

public abstract record StudentGroupForManipulationDto
{
    [Required(ErrorMessage = "StudentId is required.")]
    public Guid StudentId { get; init; }

    [Required(ErrorMessage = "GroupId is required.")]
    public Guid GroupId { get; init; }
    
    [Required(ErrorMessage = "Status is required.")]
    public StudentGroupStatus Status { get; init; }

    [MaxLength(250, ErrorMessage = "Maximum length for the Note is 250 characters.")]
    public string? Note { get; init; }

    [Required(ErrorMessage = "Start date is required.")]
    public DateTimeOffset StartedAt { get; init; }

    public DateTimeOffset? FinishedAt { get; init; }
}
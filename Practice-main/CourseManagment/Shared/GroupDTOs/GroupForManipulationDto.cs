using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Shared.GroupDTOs;

public abstract record GroupForManipulationDto
{
    [Required(ErrorMessage = "Group name is a required field.")]
    [MaxLength(250, ErrorMessage = "Maximum length for the Group Name is 250 characters.")]
    public string Name { get; init; }

    [Required(ErrorMessage = "Start date is a required field.")]
    public DateTimeOffset StartedAt { get; init; }

    [Required(ErrorMessage = "Finish date is a required field.")]
    public DateTimeOffset FinishedAt { get; init; }

    [Required(ErrorMessage = "Status is required.")]
    public GroupStatus Status { get; init; }

    [Required(ErrorMessage = "Course ID is required.")]
    public Guid CourseId { get; init; }

}
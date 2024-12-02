using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Shared.CourseDTOs;

public abstract record CourseForManipulationDto
{
    [Required(ErrorMessage = "Course name is a required field.")]
    [MaxLength(250, ErrorMessage = "Maximum length for the Course Name is 250 characters.")]
    public string Name { get; init; }

    [MaxLength(550, ErrorMessage = "Maximum length for the Subtitle is 550 characters.")]
    public string? SubTitle { get; init; }

    [MaxLength(60, ErrorMessage = "Maximum length for the Logo is 60 characters.")]
    public string? Logo { get; init; }

    [Required(ErrorMessage = "Status is required.")]
    public Status Status { get; init; }
}
using System.ComponentModel.DataAnnotations;

namespace Shared.StudentDTOs;

public abstract record StudentForManipulationDto
{
    [Required(ErrorMessage = "Student name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; init; }

    [Range(2, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 2")]
    public int Age { get; init; }

    [Range(1, int.MaxValue, ErrorMessage = "Course is required and it can't be lower than 1")]
    public int Course { get; init; }
}
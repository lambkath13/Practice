using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Shared.StudentDTOs;
public abstract record StudentForManipulationDto
{
    [Required(ErrorMessage = "Student name is a required field.")]
    [MaxLength(250, ErrorMessage = "Maximum length for the First Name is 250 characters.")]
    public string? FirstName { get; init; }

    [Required(ErrorMessage = "Student name is a required field.")]
    [MaxLength(250, ErrorMessage = "Maximum length for the Last Name is 250 characters.")]
    public string? LastName { get; init; }

    [Required(ErrorMessage = "Date of birth is a required field.")]
    public DateTimeOffset BornDate { get; init; }

    [Required(ErrorMessage = "Gender is required.")]
    public Gender Gender { get; init; }

    [Range(2, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 2.")]
    public int Age { get; init; }

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; init; }

    [MaxLength(50, ErrorMessage = "Maximum length for the Phone is 50 characters.")]
    public string? Phone { get; init; }

    [Required(ErrorMessage = "Status is required.")]
    public Status Status { get; init; }

    [Required(ErrorMessage = "Registration date is required.")]
    public DateTimeOffset RegisteredAt { get; init; }
}
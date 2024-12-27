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

}
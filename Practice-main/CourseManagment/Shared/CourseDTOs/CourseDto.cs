using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Shared.CourseDTOs;

public class CourseDto
{
    public Guid Id { get; set; }
    [MaxLength(250)]
    public string Name { get; set; }
    [MaxLength(550)]
    public string? SubTitle { get; set; }
    [MaxLength(60)]
    public string? Logo { get; set; }
    public Status Status { get; set; }

}
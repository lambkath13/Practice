using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Models;

public class Syllabus
{
    public Guid Id { get; set; }

    [MaxLength(250)]
    public required string Name { get; set; }
    [MaxLength(550)]
    public required string Description { get; set; }
    public Status Status { get; set; }
    public SyllabusType SyllabusType { get; set; }
    public Guid CourseId { get; set; }

}
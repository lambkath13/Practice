using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Models;

public class Resource
{
    
    public Guid Id { get; set; }

    [MaxLength(250)]
    public required string Name { get; set; }
    public Guid SyllabusId { get; set; }
    [MaxLength(550)]
    public required string Data { get; set; }
    public  ResourceType ResourceType { get; set; }
    
    //navigation
    public Syllabus Syllabus { get; set; } = null!;
}
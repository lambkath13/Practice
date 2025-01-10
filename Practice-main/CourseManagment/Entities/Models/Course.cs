using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Course
{
    public Guid Id { get; set; }

    [MaxLength(250)]
    public required string Name { get; set; }
    [MaxLength(550)]
    public required string Description { get; set; }
    [MaxLength(60)]
    public required string Logo { get; set; }
    public Status Status { get; set; } 
    public Guid CategoryId  { get; set; }
    
    //navigation
    public List<Category> Category { get; set; } = [];
    public List<Group> Group { get; set; } = [];
    public List<Syllabus> Syllabus { get; set; } = [];
}
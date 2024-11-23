using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Student
{
    [Column("StudentId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Student name is required ")]
    [MaxLength(30,ErrorMessage = "Maximum length for the Name is 30 characters")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Age is required" )]
    public int Age { get; set; }
    
    [Required(ErrorMessage = "Course is required" )]
    public int Course { get; set; }
    
}
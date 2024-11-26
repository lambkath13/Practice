using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Course
{
    [Column("CourseId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Course name is required field ")]
    [MaxLength(20,ErrorMessage = "Maximum length Name is 20")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Number of groups is required ")]
    public int NumberOfGroups { get; set; }
    
    [Required(ErrorMessage = "Number of students is required ")]
    public int NumberOfStudents { get; set; }
    

}
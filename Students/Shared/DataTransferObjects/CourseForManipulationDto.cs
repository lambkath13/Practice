using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record CourseForManipulationDto
{
    [Required(ErrorMessage = "Course name is required field ")]
    [MaxLength(20,ErrorMessage = "Maximum length Name is 20")]
    public string? Name { get; set; }
    
    [Range(1,int.MaxValue,ErrorMessage = "Number of groups is required ")]
    public int NumberOfGroups { get; set; }
    
    [Range(10,int.MaxValue,ErrorMessage = "Number of students is required ")]
    public int NumberOfStudents { get; set; }
    
    public IEnumerable<StudentForCreationDto> Student { get; set; }
}
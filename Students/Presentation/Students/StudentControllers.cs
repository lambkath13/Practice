using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Student.Presentation.StudentControllers;

[Route("api/course/{courseId}/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IServiceManager _service; 
    public StudentController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetStudents(Guid courseId)
    {
            var student = _service.StudentService.GetAllStudents(courseId,trackChanges: false);
            return Ok(student);
    }
    
    [HttpGet("{id:guid}", Name = "GetStudentForCourse")]
    public  IActionResult GetStudentById(Guid courseId,Guid id)
    {
        var student =  _service.StudentService.GetStudentById(courseId,id, trackChanges: false);
        if (student == null)
        {
            return NotFound($"Student  with id: {id} doesn't exist");
        }

        return Ok(student);
    }

    [HttpPost]
    public IActionResult CreateStudent(Guid courseId,[FromBody] StudentForCreationDto student)
    {
        if (student is null)
            return BadRequest("StudentForCreationDto is null");
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var createdStudent = _service.StudentService.CreateStudent(courseId,student,trackChanges:false);
        return CreatedAtRoute("GetStudentForCourse", new {courseId, id = createdStudent.Id }, createdStudent);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteStudent(Guid courseId,Guid id)//courseId
    {
        _service.StudentService.DeleteStudent(courseId,id,trackChanges:false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateStudent(Guid courseId,Guid id, [FromBody] StudentForUpdateDto student)//courseId
    {
        if (student is null)
        {
            return BadRequest("CompanyForUpdateDto is null");
        }
        _service.StudentService.UpdateStudents(courseId,id,student,couTrackChanges:false,stuTrackChanges:true);
        return NoContent();
    }
}
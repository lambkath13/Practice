using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Student.Presentation.StudentControllers;

[Route("api/students")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IServiceManager _service;

    public StudentController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
            var student = _service.StudentService.GetAllStudents(trackChanges: false);
            return Ok(student);
    }
    
    [HttpGet("{id:guid}", Name = "StudentById")]
    public  IActionResult GetStudentById(Guid id)
    {
        var student =  _service.StudentService.GetStudentById(id, trackChanges: false);
        if (student == null)
        {
            return NotFound($"Student  with id: {id} doesn't exist");
        }

        return Ok(student);
    }

    [HttpPost]
    public IActionResult CreateStudent([FromBody] StudentForCreationDto student)
    {
        if (student is null)
            return BadRequest("StudentForCreationDto is null");
        var createdStudent = _service.StudentService.CreateStudent(student);
        return CreatedAtRoute("StudentById", new { id = createdStudent.Id }, createdStudent);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteStudent(Guid id)
    {
        _service.StudentService.DeleteStudent(id,trackChanges:false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateStudent(Guid id, [FromBody] StudentForUpdateDto student)
    {
        if (student is null)
        {
            return BadRequest("CompanyForUpdateDto is null");
        }
        _service.StudentService.UpdateStudents(id,student,trackChanges:true);
        return NoContent();
    }
}
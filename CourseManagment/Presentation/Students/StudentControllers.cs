using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.StudentDTOs;

namespace Presentation.Students;

[Route("api/students/")]
[ApiController]

public class StudentController(IServiceManager service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents()
    {
        var student = service.StudentService.GetAllStudents(trackChanges: false);

        return Ok(student);
    }

    [HttpGet("{id:guid}", Name = "GetStudentForCourse")]
    public IActionResult GetStudentById(Guid id)
    {
        var student = service.StudentService.GetStudentById(id, trackChanges: false);
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

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdStudentId = service.StudentService.CreateStudent(student, trackChanges: false);

        return CreatedAtRoute("GetStudentForCourse", new { id = createdStudentId });
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteStudent(Guid id)//courseId
    {
        service.StudentService.DeleteStudent(id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateStudent(Guid id, [FromBody] StudentForUpdateDto student)//courseId
    {
        if (student is null)
        {
            return BadRequest("CompanyForUpdateDto is null");
        }

        service.StudentService.UpdateStudents(id, student, couTrackChanges: false, stuTrackChanges: true);

        return NoContent();
    }
}
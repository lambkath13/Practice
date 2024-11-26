using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Student.Presentation.StudentControllers;
[Route("api/course")]
[ApiController]
public class CourseController:ControllerBase
{
    private readonly IServiceManager _service;
    public CourseController(IServiceManager service) => _service = service;
    
    [HttpGet]
    public IActionResult GetAllCourse()
    {
        var course = _service.CourseService.GetAllCourse(trackChanges: false);
        return Ok(course);
    }

    [HttpGet("{id:guid}", Name = "CourseById")]
    public IActionResult GetCourseById(Guid id)
    {
        var course = _service.CourseService.GetCourseById(id, trackChanges: false);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    [HttpPost]
    public IActionResult CreateCourse([FromBody] CourseForCreationDto course)
    {
        if (course is null)
            return BadRequest("CourseForCreationDto is null");
        
        var createCourse = _service.CourseService.CreateCourse(course);
        return CreatedAtRoute("CourseById", new { id = createCourse.Id }, createCourse);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCourse(Guid id, bool trackChanges)
    {
        _service.CourseService.DeleteCourse(id,trackChanges:false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCourse(Guid id, [FromBody] CourseForUpdateDto course)
    {
        if (course is null)
            return BadRequest("CourseForUpdateDto is null");
        
        _service.CourseService.UpdateCourse(id,course,trackChanges:false);
        return NoContent();
    }
    
}
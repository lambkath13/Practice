using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.CourseDTOs;

namespace Presentation.Courses;

<<<<<<<< HEAD:Practice-main/CourseManagment/Presentation/Courses/CourseController.cs
[Route("api/courses")]
========
[Route("api/courses/")]
>>>>>>>> 29a20d7bfa39aa64776ca5dc94fce333e8260878:CourseManagment/Presentation/Courses/CourseController.cs
[ApiController]
public class CourseController(IServiceManager service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllCourse()
    {
        var course = service.CourseService.GetAllCourse(trackChanges: false);

        return Ok(course);
    }

    [HttpGet("{id:guid}", Name = "CourseById")]
    public IActionResult GetCourseById(Guid id)
    {
        var course = service.CourseService.GetCourseById(id, trackChanges: false);
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

        var createCourseId = service.CourseService.CreateCourse(course);

<<<<<<<< HEAD:Practice-main/CourseManagment/Presentation/Courses/CourseController.cs
        return CreatedAtRoute("CourseById", new { id = createCourseId },course);
========
        return CreatedAtRoute("CourseById", new { id = createCourseId });
>>>>>>>> 29a20d7bfa39aa64776ca5dc94fce333e8260878:CourseManagment/Presentation/Courses/CourseController.cs
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCourse(Guid id, bool trackChanges)
    {
        service.CourseService.DeleteCourse(id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCourse(Guid id, [FromBody] CourseForUpdateDto course)
    {
        if (course is null)
            return BadRequest("CourseForUpdateDto is null");

        service.CourseService.UpdateCourse(id, course, trackChanges: false);

        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.StudentGroupDTOs;

namespace Presentation.StudentGroups;

[Route("api/studentGroup")]
[ApiController]
public class StudentGroupController(IServiceManager service):ControllerBase
{
    [HttpGet]
    public IActionResult GetAllStudentGroup()
    {
        var studentGroup = service.StudentGroupService.GetAllStudentGroup(trackChanges: false);
        return Ok(studentGroup);
    }

    [HttpGet("{studentId:guid}/{groupId:guid}", Name = "StudentGroupById")]
    public IActionResult GetStudentGroupById(Guid studentId, Guid groupId)
    {
        var studentGroup = service.StudentGroupService.GetStudentGroupById(studentId, groupId, trackChanges: false);
        if (studentGroup == null)
        {
            return NotFound();
        }

        return Ok(studentGroup);
    }

    [HttpPost]
    public IActionResult CreateStudentGroup([FromBody] StudentGroupForCreationDto studentGroup)
    {
        if (studentGroup is null)
            return BadRequest("StudentGroupForCreationDto is null");

        var createStudentGroup = service.StudentGroupService.CreateStudentGroup(studentGroup);
        return CreatedAtRoute("StudentGroupById", new { studentId = createStudentGroup.StudentId, groupId = createStudentGroup.GroupId }, studentGroup);
    }
    
    [HttpDelete("{studentId:guid}/{groupId:guid}")]
    public IActionResult DeleteStudentGroup(Guid studentId, Guid groupId, bool trackChanges)
    {
        service.StudentGroupService.DeleteStudentGroup(studentId, groupId, trackChanges:false);
        return NoContent();
    }

    [HttpPut("{studentId:guid}/{groupId:guid}")]
    public IActionResult UpdateStudentGroup(Guid studentId, Guid groupId, [FromBody] StudentGroupForUpdateDto studentGroup)
    {
        if (studentGroup is null)
            return BadRequest("GroupForUpdateDto is null");
        
        service.StudentGroupService.UpdateStudentGroup(studentId,groupId,studentGroup,trackChanges:false);
        return NoContent();
    }
    
}
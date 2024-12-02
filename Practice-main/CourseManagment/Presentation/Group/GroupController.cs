using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.GroupDto;

namespace Presentation.Group;

[Route("api/groups")]
[ApiController]
public class GroupController(IServiceManager service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllGroup()
    {
        var group = service.GroupService.GetAllGroup(trackChanges:false);
        return Ok(group);
    }

    [HttpGet("{id:guid}", Name = "GroupById")]
    public IActionResult GetGroupById(Guid id)
    {
        var group = service.GroupService.GetGroupById(id, trackChanges: false);
        if (group == null)
        {
            return NotFound();
        }

        return Ok(group);
    }

    [HttpPost]
    public IActionResult CreateGroup([FromBody] GroupForCreationDto group)
    {
        if (group is null)
            return BadRequest("GroupForCreationDto is null");

        var createGroupId = service.GroupService.CreateGroup(group);
        return CreatedAtRoute("GroupById", new { id = createGroupId },group);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteGroup(Guid id, bool trackChanges)
    {
        service.GroupService.DeleteGroup(id,trackChanges:false);
        
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateGroup(Guid id, [FromBody] GroupForUpdateDto group)
    {
        if (group is null)
            return BadRequest("GroupForUpdateDto is null");
        
        service.GroupService.UpdateGroup(id,group,trackChanges:false);
        return NoContent();
    }
    
}
using Entities.Models;
using Shared.GroupDTOs;
using Group = System.Text.RegularExpressions.Group;

namespace Service;

public interface IGroupService
{
    IEnumerable<GroupDto> GetAllGroup(bool trackChanges);
    GroupDto GetGroupById(Guid groupId, bool trackChanges);
    Guid CreateGroup(GroupForCreationDto group);
    void DeleteGroup(Guid groupId, bool trackChanges);
    void UpdateGroup(Guid groupId, GroupForUpdateDto groupForUpdateDto, bool trackChanges);
}
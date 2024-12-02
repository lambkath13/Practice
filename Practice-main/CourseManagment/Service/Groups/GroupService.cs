using AutoMapper;
using Contracts;
using Entities.Models;
using Shared.GroupDto;

namespace Service.Groups;

public sealed class GroupService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : IGroupService
{
    public IEnumerable<GroupDto> GetAllGroup(bool trackChanges)
    {
        var group = repository.Group.GetAllGroup(trackChanges);

        var groupDto = mapper.Map<IEnumerable<GroupDto>>(group);

        return groupDto;
    }

    public GroupDto GetGroupById(Guid groupId, bool trackChanges)
    {
        var group = repository.Group.GetGroupById(groupId,trackChanges);

        var groupDto = mapper.Map<GroupDto>(group);

        return groupDto;    
    }

    public Guid CreateGroup(GroupForCreationDto group)
    {
        var groupEntity = mapper.Map<Group>(group);
        repository.Group.CreateGroup(groupEntity);

        repository.Save();

        return groupEntity.Id;
    }

    public void DeleteGroup(Guid groupId, bool trackChanges)
    {
        var group = repository.Group.GetGroupById(groupId, trackChanges);
        if (group is null)
        {
            throw new KeyNotFoundException("Group not found");
        }

        repository.Group.DeleteGroup(group);

        repository.Save();    }

    public void UpdateGroup(Guid groupId, GroupForUpdateDto groupForUpdateDto, bool trackChanges)
    {
        var groupEntity = repository.Group.GetGroupById(groupId, trackChanges);
        if (groupEntity is null)
        {
            throw new KeyNotFoundException("Group not found");
        }

        mapper.Map(groupForUpdateDto, groupEntity);

        repository.Save();
        
    }
}
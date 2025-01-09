using Entities.Models;

namespace Contracts;

public interface IGroupRepository
{
    IEnumerable<Group> GetAllGroup(bool trackChanges);

    Group? GetGroupById(Guid groupId,bool trackChanges);

    void CreateGroup(Group group);

    void DeleteGroup(Group group);
}
using Contracts;
using Entities.Models;
using Repository.OtherRepository;

namespace Repository.GroupRepository;

public class GroupRepository(RepositoryContext repositoryContext) : RepositoryBase<Group>(repositoryContext), IGroupRepository
{
    public IEnumerable<Group> GetAllGroup(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

    public Group? GetGroupById(Guid groupId, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(groupId), trackChanges)
            .SingleOrDefault();

    public void CreateGroup(Group group) => Create(group);

    public void DeleteGroup(Group group) => Delete(group);
}
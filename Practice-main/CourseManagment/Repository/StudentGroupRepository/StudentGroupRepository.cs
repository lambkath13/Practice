using Contracts;
using Entities.Models;
using Repository.OtherRepository;

namespace Repository.StudentGroupRepository;

public class StudentGroupRepository(RepositoryContext repositoryContext) : RepositoryBase<StudentGroup>(repositoryContext),IStudentGroupRepository
{
    public IEnumerable<StudentGroup> GetAllStudentGroup(bool trackChanges) =>
        FindAll(trackChanges)
            .ToList();

    public StudentGroup GetStudentGroupById(Guid studentId, Guid groupId, bool trackChanges) =>
        FindByCondition(c => c.StudentId.Equals(studentId) && c.GroupId.Equals(groupId), trackChanges)
            .SingleOrDefault();

    public void CreateStudentGroup(StudentGroup studentGroup) => Create(studentGroup);

    public void DeleteStudentGroup(StudentGroup studentGroup) => Delete(studentGroup);
}
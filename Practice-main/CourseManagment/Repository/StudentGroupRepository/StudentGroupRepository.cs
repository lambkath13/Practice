using Contracts;
using Entities.Enums;
using Entities.Models;
using Repository.OtherRepository;

namespace Repository.StudentGroupRepository;

public class StudentGroupRepository(RepositoryContext repositoryContext) : RepositoryBase<StudentGroup>(repositoryContext), IStudentGroupRepository
{
    public StudentGroup? GetStudentGroupById(Guid studentId, Guid groupId, bool trackChanges) =>
        FindByCondition(c => c.StudentId.Equals(studentId) && c.GroupId.Equals(groupId), trackChanges)
            .SingleOrDefault();

    public void CreateStudentGroup(StudentGroup studentGroup)
    {
        studentGroup.Status = StudentGroupStatus.Active;

        Create(studentGroup); 
    }
    
}

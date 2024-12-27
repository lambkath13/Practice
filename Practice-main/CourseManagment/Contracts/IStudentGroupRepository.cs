using Entities.Models;

namespace Contracts;

public interface IStudentGroupRepository
{
    StudentGroup GetStudentGroupById(Guid studentId, Guid groupId, bool trackChanges);
    void CreateStudentGroup(StudentGroup studentGroup);

}
using Entities.Models;

namespace Contracts;

public interface IStudentGroupRepository
{
    IEnumerable<StudentGroup> GetAllStudentGroup(bool trackChanges);
    StudentGroup GetStudentGroupById(Guid studentId, Guid groupId, bool trackChanges);
    void CreateStudentGroup(StudentGroup studentGroup);
    void DeleteStudentGroup(StudentGroup studentGroup);
}
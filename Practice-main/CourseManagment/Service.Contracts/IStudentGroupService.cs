using Shared.StudentGroupDTOs;

namespace Service;

public interface IStudentGroupService
{
    IEnumerable<StudentGroupDto> GetAllStudentGroup(bool trackChanges);
    StudentGroupDto GetStudentGroupById(Guid studentId, Guid groupId, bool trackChanges);
    (Guid StudentId, Guid GroupId) CreateStudentGroup(StudentGroupForCreationDto studentGroup);
    void DeleteStudentGroup(Guid studentId, Guid groupId, bool trackChanges);
    void UpdateStudentGroup(Guid studentId, Guid groupId, StudentGroupForUpdateDto studentGroup,bool trackChanges);
}
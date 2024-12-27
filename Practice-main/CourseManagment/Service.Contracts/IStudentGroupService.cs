using Shared.StudentGroupDTOs;

namespace Service;

public interface IStudentGroupService
{
    StudentGroupDto GetStudentGroupById(Guid studentId, Guid groupId, bool trackChanges);
    (Guid StudentId, Guid GroupId) CreateStudentGroup(StudentGroupForCreationDto studentGroup);
    void UpdateStudentGroup(Guid studentId, Guid groupId, StudentGroupForUpdateDto studentGroup,bool trackChanges);

}
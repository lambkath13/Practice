
using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IStudentService
{
    IEnumerable<StudentDto> GetAllStudents(bool trackChanges);
    StudentDto GetStudentById(Guid studentId, bool trackChanges);
    StudentDto CreateStudent(StudentForCreationDto student);
    void DeleteStudent(Guid studentId, bool trackChanges);
    void UpdateStudents(Guid studentId, StudentForUpdateDto studentForUpdate, bool trackChanges);

}
using Shared.StudentDTOs;

namespace Service;

public interface IStudentService
{
    IEnumerable<StudentDto> GetAllStudents(bool trackChanges);
    StudentDto? GetStudentById(Guid id, bool trackChanges);
    Guid CreateStudent(StudentForCreationDto student, bool trackChanges);
    void DeleteStudent(Guid id, bool trackChanges);
    void UpdateStudents(Guid id, StudentForUpdateDto studentForUpdate, bool couTrackChanges, bool stuTrackChanges);
}
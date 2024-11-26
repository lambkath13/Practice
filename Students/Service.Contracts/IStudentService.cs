
using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IStudentService
{
    IEnumerable<StudentDto> GetAllStudents(Guid courseId,bool trackChanges);
    StudentDto GetStudentById(Guid courseId, Guid id, bool trackChanges);
    StudentDto CreateStudent(Guid courseId,StudentForCreationDto student,bool trackChanges);
    void DeleteStudent(Guid companyId,Guid id, bool trackChanges);
    void UpdateStudents(Guid courseId,Guid id, StudentForUpdateDto studentForUpdate, bool couTrackChanges,bool stuTrackChanges);

}
using Entities;

namespace Contracts;

public interface IStudentRepository
{
    IEnumerable<Student> GetAllStudents(Guid courseId,bool trackChanges);
    Student GetStudentById(Guid courseId, Guid id, bool trackChanges);
    void CreateStudent(Guid courseId,Student student);
    void DeleteStudent(Student student);
    

}
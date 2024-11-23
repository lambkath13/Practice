using Entities;

namespace Contracts;

public interface IStudentRepository
{
    IEnumerable<Student> GetAllStudents(bool trackChanges);
    Student GetStudentById(Guid studentId,bool trackChanges);
    void CreateStudent(Student student);
    void DeleteStudent(Student student);

}
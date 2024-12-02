using Entities.Models;

namespace Contracts;

public interface IStudentRepository
{
    IEnumerable<Student> GetAllStudents(bool trackChanges);
    Student? GetStudentById(Guid id, bool trackChanges);
    void CreateStudent(Student student);
    void DeleteStudent(Student student);
}
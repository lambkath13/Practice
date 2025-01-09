using Entities.Models;

namespace Contracts;

public interface IStudentRepository
{
    IEnumerable<User> GetAllStudents(bool trackChanges);
    User? GetStudentById(Guid id, bool trackChanges);
    void CreateStudent(User user);
    void DeleteStudent(User user);
}
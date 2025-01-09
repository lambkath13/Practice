using Contracts;
using Entities.Models;
using Repository.OtherRepository;

namespace Repository.StudentRepository;

public class StudentRepository(RepositoryContext repositoryContext) : RepositoryBase<User>(repositoryContext), IStudentRepository
{
    public IEnumerable <User> GetAllStudents(bool trackChanges) =>
         FindAll(trackChanges)
            .OrderByDescending(c => c.RegisteredAt)
                .ToList();

    public User? GetStudentById(Guid id, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefault();

    public void CreateStudent(User user)
    {
        Create(user);
    }

    public void DeleteStudent(User user) => Delete(user);
}
using Contracts;
using Entities.Models;
using Repository.OtherRepository;

namespace Repository;

public class StudentRepository(RepositoryContext repositoryContext) : RepositoryBase<Student>(repositoryContext), IStudentRepository
{
    public IEnumerable <Student> GetAllStudents(bool trackChanges) =>
         FindAll(trackChanges)
            .OrderByDescending(c => c.RegisteredAt)
                .ToList();

    public Student? GetStudentById(Guid id, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefault();

    public void CreateStudent(Student student)
    {
        Create(student);
    }

    public void DeleteStudent(Student student) => Delete(student);
}
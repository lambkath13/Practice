using System.Collections;
using Contracts;
using Entities;

namespace Repository;

public class StudentRepository:RepositoryBase<Student>,IStudentRepository
{
    public StudentRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable <Student> GetAllStudents(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

    public Student GetStudentById(Guid studentId, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(studentId), trackChanges)
            .SingleOrDefault();


    public void CreateStudent(Student student) => Create(student);
    public void DeleteStudent(Student student) => Delete(student);
}
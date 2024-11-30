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

    public IEnumerable <Student> GetAllStudents(Guid courseId,bool trackChanges) =>
        FindByCondition(c =>c.Id.Equals(courseId), trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

    public Student GetStudentById(Guid courseId, Guid id, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(courseId), trackChanges)
            .SingleOrDefault();


    public void CreateStudent(Guid courseId, Student student)
    {
        student.Id = courseId;
    }
    public void DeleteStudent(Student student) => Delete(student);
}
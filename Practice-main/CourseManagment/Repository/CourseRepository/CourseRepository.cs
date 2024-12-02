using Contracts;
using Entities.Models;
using Repository.OtherRepository;


namespace Repository;

public class CourseRepository(RepositoryContext repositoryContext) : RepositoryBase<Course>(repositoryContext), ICourseRepository
{
    public IEnumerable<Course> GetAllCourse(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

    public Course? GetCourseById(Guid courseId, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(courseId), trackChanges)
            .SingleOrDefault();

    public void CreateCourse(Course course) => Create(course);

    public void DeleteCourse(Course course) => Delete(course);
}
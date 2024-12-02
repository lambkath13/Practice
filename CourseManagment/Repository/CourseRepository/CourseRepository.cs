using Contracts;
using Entities.Models;
using Repository.OtherRepository;
<<<<<<<< HEAD:Practice-main/CourseManagment/Repository/CourseRepository/CourseRepository.cs

========
>>>>>>>> 29a20d7bfa39aa64776ca5dc94fce333e8260878:CourseManagment/Repository/CourseRepository/CourseRepository.cs

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
using Entities;

namespace Contracts;

public interface ICourseRepository
{
    IEnumerable<Course> GetAllCourse(bool trackChanges);
    Course GetCourseById(Guid courseId,bool trackChanges);
    void CreateCourse(Course course);
    void DeleteCourse(Course course);

}
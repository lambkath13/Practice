using Shared.CourseDTOs;

namespace Service;

public interface ICourseService
{
    IEnumerable<CourseDto> GetAllCourse(bool trackChanges);
    CourseDto GetCourseById(Guid courseId, bool trackChanges);
    Guid CreateCourse(CourseForCreationDto course);
    void DeleteCourse(Guid courseId, bool trackChanges);
    void UpdateCourse(Guid courseId, CourseForUpdateDto courseForUpdateDto, bool trackChanges);
}
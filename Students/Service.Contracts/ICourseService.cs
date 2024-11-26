using Entities;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICourseService
{
    IEnumerable<CourseDto> GetAllCourse(bool trackChanges);
    CourseDto GetCourseById(Guid courseId, bool trackChanges);
    CourseDto CreateCourse(CourseForCreationDto course);
    void DeleteCourse(Guid courseId, bool trackChanges);
    void UpdateCourse(Guid courseId, CourseForUpdateDto courseForUpdateDto, bool trackChanges);

}
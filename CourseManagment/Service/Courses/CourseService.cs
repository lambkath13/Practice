using AutoMapper;
using Contracts;
using Entities.Models;
using Shared.CourseDTOs;

namespace Service.Courses;

public sealed class CourseService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : ICourseService
{
    public IEnumerable<CourseDto> GetAllCourse(bool trackChanges)
    {
        var course = repository.Course.GetAllCourse(trackChanges);

        var courseDto = mapper.Map<IEnumerable<CourseDto>>(course);

        return courseDto;
    }

    public CourseDto GetCourseById(Guid courseId, bool trackChanges)
    {
        var course = repository.Course.GetCourseById(courseId, trackChanges);

        var courseDto = mapper.Map<CourseDto>(course);

        return courseDto;
    }

    public Guid CreateCourse(CourseForCreationDto course)
    {
        var courseEntity = mapper.Map<Course>(course);

        repository.Course.CreateCourse(courseEntity);

        return courseEntity.Id;

    }

    public void DeleteCourse(Guid courseId, bool trackChanges)
    {
        var course = repository.Course.GetCourseById(courseId, trackChanges);
        if (course is null)
        {
            throw new KeyNotFoundException("Course not found");
        }

        repository.Course.DeleteCourse(course);

        repository.Save();
    }

    public void UpdateCourse(Guid courseId, CourseForUpdateDto courseForUpdateDto, bool trackChanges)
    {
        var courseEntity = repository.Course.GetCourseById(courseId, trackChanges);
        if (courseEntity is null)
        {
            throw new KeyNotFoundException("Student not found");
        }

        mapper.Map(courseForUpdateDto, courseEntity);

        repository.Save();
    }
}
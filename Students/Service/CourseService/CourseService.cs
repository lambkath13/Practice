using AutoMapper;
using Contracts;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class CourseService:ICourseService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CourseService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CourseDto> GetAllCourse(bool trackChanges)
    {
        var course = _repository.Course.GetAllCourse(trackChanges);
        var courseDto = _mapper.Map<IEnumerable<CourseDto>>(course);
        return courseDto;
    }

    public CourseDto GetCourseById(Guid courseId, bool trackChanges)
    {
        var course = _repository.Course.GetCourseById(courseId, trackChanges);
        var courseDto = _mapper.Map<CourseDto>(course);
        return courseDto;
    }

    public CourseDto CreateCourse(CourseForCreationDto course)
    {
        var courseEntity = _mapper.Map<Course>(course);
        _repository.Course.CreateCourse(courseEntity);
        var courseToReturn = _mapper.Map<CourseDto>(courseEntity);
        return courseToReturn;

    }

    public void DeleteCourse(Guid courseId, bool trackChanges)
    {
        var course = _repository.Course.GetCourseById(courseId, trackChanges);
        if (course is null)
        {
            throw new KeyNotFoundException("Course not found");
        }
        _repository.Course.DeleteCourse(course);
        _repository.Save();
    }

    public void UpdateCourse(Guid courseId, CourseForUpdateDto courseForUpdateDto, bool trackChanges)
    {
        var courseEntity = _repository.Course.GetCourseById(courseId, trackChanges);
        if (courseEntity is null)
        {
            throw new KeyNotFoundException("Student not found");
        }

        _mapper.Map(courseForUpdateDto, courseEntity);
        _repository.Save();
    }  
}
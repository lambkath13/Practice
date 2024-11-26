using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

namespace Students;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Entities.Student, StudentDto>();
        CreateMap<StudentForCreationDto, Entities.Student>();
        CreateMap<StudentForUpdateDto, Entities.Student>();
        CreateMap<Course, CourseDto>();
        CreateMap<CourseForCreationDto, Course>();
        CreateMap<CourseForUpdateDto, Course>();

    }
}
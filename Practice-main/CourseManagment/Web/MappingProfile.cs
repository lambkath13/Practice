using AutoMapper;
using Entities.Models;
using Shared.CourseDTOs;
using Shared.GroupDTOs;
using Shared.StudentDTOs;
using Shared.StudentGroupDTOs;

namespace Web;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentForCreationDto, Student>();
        CreateMap<StudentForUpdateDto, Student>();
        CreateMap<Course, CourseDto>();
        CreateMap<CourseForCreationDto, Course>();
        CreateMap<CourseForUpdateDto, Course>();
        CreateMap<Group,GroupDto>();
        CreateMap<GroupForCreationDto, Group>();
        CreateMap<GroupForUpdateDto,Group>();
        CreateMap<StudentGroup, StudentGroupDto>();
        CreateMap<StudentGroupForCreationDto, StudentGroup>();
        CreateMap<StudentGroupForUpdateDto, StudentGroup>();
        

    }
}
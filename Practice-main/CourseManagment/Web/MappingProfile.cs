﻿using AutoMapper;
using Entities.Models;
using Shared.CourseDTOs;
using Shared.GroupDto;
using Shared.StudentDTOs;

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

    }
}
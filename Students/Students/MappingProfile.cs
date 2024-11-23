using AutoMapper;
using Shared.DataTransferObjects;

namespace Students;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Entities.Student, StudentDto>();
        CreateMap<StudentForCreationDto, Entities.Student>();
        CreateMap<StudentForUpdateDto, Entities.Student>();
    }
}
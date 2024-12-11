using AutoMapper;
using Contracts;
using Entities.Models;
using Shared.StudentGroupDTOs;

namespace Service.StudentGroups;

public class StudentGroupService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) :IStudentGroupService
{

    public IEnumerable<StudentGroupDto> GetAllStudentGroup(bool trackChanges)
    {
        var studentGroup = repository.StudentGroup.GetAllStudentGroup(trackChanges);
        
        var studentGroupDto = mapper.Map<IEnumerable<StudentGroupDto>>(studentGroup);
        
        return studentGroupDto;
    }

    public StudentGroupDto GetStudentGroupById(Guid studentId, Guid groupId, bool trackChanges)
    {
        var studentGroup = repository.StudentGroup.GetStudentGroupById(studentId, groupId, trackChanges);
        
        var studentGroupDto = mapper.Map<StudentGroupDto>(studentGroup);
        
        return studentGroupDto;
    }

    public (Guid StudentId, Guid GroupId) CreateStudentGroup(StudentGroupForCreationDto studentGroup)
    {
        var courseGroupEntity = mapper.Map<StudentGroup>(studentGroup);
        repository.StudentGroup.CreateStudentGroup(courseGroupEntity);
        repository.Save();
        return (courseGroupEntity.StudentId,courseGroupEntity.GroupId);
    }

    public void DeleteStudentGroup(Guid studentId, Guid groupId, bool trackChanges)
    {
        var studentGroup = repository.StudentGroup.GetStudentGroupById(studentId, groupId, trackChanges);
        if (studentGroup is null)
        {
            throw new KeyNotFoundException("StudentGroup not found");
        }
        repository.StudentGroup.DeleteStudentGroup(studentGroup);
        repository.Save();
    }

    public void UpdateStudentGroup(Guid studentId, Guid groupId, StudentGroupForUpdateDto studentGroupForUpdateDto,
        bool trackChanges)
    {
        var studentGroupEntity = repository.StudentGroup.GetStudentGroupById(studentId, groupId, trackChanges);
        if (studentGroupEntity is null)
        {
            throw new KeyNotFoundException("StudentGroup not found");
        }

        mapper.Map(studentGroupForUpdateDto, studentGroupEntity);
        repository.Save();
    }
}
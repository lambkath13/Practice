using AutoMapper;
using Contracts;
using Entities.Enums;
using Entities.Models;
using Shared.StudentGroupDTOs;

namespace Service.StudentGroups;

public class StudentGroupService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) :IStudentGroupService
{
    public StudentGroupDto GetStudentGroupById(Guid studentId, Guid groupId, bool trackChanges)
    {
        var studentGroup = repository.StudentGroup.GetStudentGroupById(studentId, groupId, trackChanges);
        
        var studentGroupDto = mapper.Map<StudentGroupDto>(studentGroup);
        
        return studentGroupDto;
    }
    
    public (Guid StudentId, Guid GroupId) CreateStudentGroup(StudentGroupForCreationDto studentGroup)
    {
        var studentGroupEntity = mapper.Map<StudentGroup>(studentGroup);
        studentGroupEntity.Status = StudentGroupStatus.Active;

        repository.StudentGroup.CreateStudentGroup(studentGroupEntity);
        repository.Save();
        return (studentGroupEntity.UserId,studentGroupEntity.GroupId);
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
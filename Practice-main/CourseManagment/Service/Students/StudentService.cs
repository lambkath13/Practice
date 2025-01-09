using AutoMapper;
using Contracts;
using Entities.Models;
using Shared.StudentDTOs;

namespace Service.Students;

public sealed class StudentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : IStudentService
{
    public IEnumerable<StudentDto> GetAllStudents(bool trackChanges)
    {
        var studentsFromDb = repository.Student.GetAllStudents(trackChanges);

        return mapper.Map<IEnumerable<StudentDto>>(studentsFromDb);
    }

    public StudentDto? GetStudentById(Guid id, bool trackChanges)
    {
        var studentDb = repository.Student.GetStudentById(id, trackChanges);
        if(studentDb == null)
            throw new Exception("Student not found");

        return mapper.Map<StudentDto>(studentDb);
    }


    public Guid CreateStudent(StudentForCreationDto studentForCreationDto, bool trackChanges)
    {
        var studentEntity = mapper.Map<User>(studentForCreationDto);

        repository.Student.CreateStudent(studentEntity);

        repository.Save();

        return studentEntity.Id;
    }

    public void DeleteStudent(Guid id, bool trackChanges)
    {
        var studentEntity = repository.Student.GetStudentById(id, trackChanges);
        if (studentEntity is null)
        {
            throw new Exception("Student not found");
        }

        repository.Student.DeleteStudent(studentEntity);

        repository.Save();
    }

    public void UpdateStudents(Guid id, StudentForUpdateDto studentForUpdate, bool couTrackChanges, bool stuTrackChanges)
    {
        var studentEntity = repository.Student.GetStudentById(id, stuTrackChanges);
        if (studentEntity is null)
        {
            throw new Exception("Student not found");
        }

        mapper.Map(studentForUpdate, studentEntity);

        repository.Save();
    }
}


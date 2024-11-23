using System.Globalization;
using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class StudentService:IStudentService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public StudentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<StudentDto> GetAllStudents(bool trackChanges)
        {

                var students = _repository.Student.GetAllStudents(trackChanges);
                var studentsDto =_mapper.Map<IEnumerable<StudentDto>>(students);
                return studentsDto;
                
        }

        public StudentDto GetStudentById(Guid studentId, bool trackChanges)
        {
            var student = _repository.Student.GetStudentById(studentId, trackChanges);
            var studentDto = _mapper.Map<StudentDto>(student);
            return studentDto;
        }


        public StudentDto CreateStudent(StudentForCreationDto student)
        {
            var studentEntity = _mapper.Map<Student>(student);
            _repository.Student.CreateStudent(studentEntity);
            _repository.Save();
            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            return studentToReturn;
        }

        public void DeleteStudent(Guid studentId, bool trackChanges)
        {
            var student = _repository.Student.GetStudentById(studentId, trackChanges);
            if (student is null)
            {
                throw new KeyNotFoundException("Student not found");
            }
            _repository.Student.DeleteStudent(student);
            _repository.Save();
        }

        public void UpdateStudents(Guid studentId, StudentForUpdateDto studentForUpdate, bool trackChanges)
        {
            var studentEntity = _repository.Student.GetStudentById(studentId, trackChanges);
            if (studentEntity is null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            _mapper.Map(studentForUpdate, studentEntity);
            _repository.Save();
        }
    }
}


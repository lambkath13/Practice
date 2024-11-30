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

        public IEnumerable<StudentDto> GetAllStudents(Guid companyId,bool trackChanges)
        {

                var company = _repository.Student.GetAllStudents(companyId,trackChanges);
                if (company is null)
                {
                    throw new Exception("Web is not found ");
                }

                var studentFromDb = _repository.Student.GetAllStudents(companyId, trackChanges);
                  return  _mapper.Map<IEnumerable<StudentDto>>(studentFromDb);
                 
                
        }

        public StudentDto GetStudentById( Guid courseId,Guid id, bool trackChanges)
        {
            var course = _repository.Course.GetCourseById(courseId, trackChanges);
            if (course is null)
            {
                throw new Exception("Student is not found ");
            }

            var studentDb = _repository.Student.GetStudentById(courseId,id, trackChanges);
              return  _mapper.Map<StudentDto>(studentDb);  
        }


        public StudentDto CreateStudent(Guid courseId,StudentForCreationDto studentForCreationDto,bool trackChanges)
        {
            var course = _repository.Course.GetCourseById(courseId,trackChanges);
            if (course is null)
            {
                throw new Exception("Student don't create");
            }
            var studentEntity = _mapper.Map<Student>(studentForCreationDto);
            _repository.Student.CreateStudent(courseId,studentEntity);
            return _mapper.Map<StudentDto>(studentEntity);

        }

        public void DeleteStudent(Guid courseId,Guid id, bool trackChanges)
        {
            var course = _repository.Course.GetCourseById(courseId, trackChanges);
            if (course is null)
            {
                throw new Exception("Student not found");
            }
            var studentEntity = _repository.Student.GetStudentById(courseId, id,trackChanges);
            if (studentEntity is null)
            {
                throw new Exception("Student not found");
            }
            _repository.Student.DeleteStudent(studentEntity);
            _repository.Save();
        }

        public void UpdateStudents(Guid courseId, Guid id,StudentForUpdateDto studentForUpdate, bool couTrackChanges, bool stuTrackChanges)
        {
            var course = _repository.Course.GetCourseById(courseId, couTrackChanges);
            if (course is null)
            {
                throw new Exception("Student not found");
            }
            var studentEntity = _repository.Student.GetStudentById(courseId, id,stuTrackChanges);
            if (studentEntity is null)
            {
                throw new Exception("Student not found");
            }

            _mapper.Map(studentForUpdate, studentEntity);
            _repository.Save();
        }
    }
}


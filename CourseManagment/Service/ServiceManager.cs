using AutoMapper;
using Contracts;
using Service.Contracts;
using Service.Courses;
<<<<<<<< HEAD:Practice-main/CourseManagment/Service/ServiceManager.cs
using Service.Groups;
========
>>>>>>>> 29a20d7bfa39aa64776ca5dc94fce333e8260878:CourseManagment/Service/ServiceManager.cs
using Service.Students;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IStudentService> _studentService;
    private readonly Lazy<ICourseService> _courseService;
    private readonly Lazy<IGroupService> _groupService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager,logger,mapper));
        _courseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager, logger, mapper));
        _groupService = new Lazy<IGroupService>(() => new GroupService(repositoryManager, logger, mapper));
    }

    public IStudentService StudentService => _studentService.Value;
    public ICourseService CourseService => _courseService.Value;
    public IGroupService GroupService => _groupService.Value;
}
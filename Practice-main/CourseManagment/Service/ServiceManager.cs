using AutoMapper;
using Contracts;
using Service.Courses;
using Service.Groups;
using Service.Statistics;
using Service.StudentGroups;
using Service.Students;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IStudentService> _studentService;
    private readonly Lazy<ICourseService> _courseService;
    private readonly Lazy<IGroupService> _groupService;
    private readonly Lazy<IStudentGroupService> _studentGroupService;
    private readonly Lazy<IStatisticsService> _statisticsService;



    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager,logger,mapper));
        _courseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager, logger, mapper));
        _groupService = new Lazy<IGroupService>(() => new GroupService(repositoryManager, logger, mapper));
        _studentGroupService = new Lazy<IStudentGroupService>(() => new StudentGroupService(repositoryManager, logger, mapper));
        _statisticsService = new Lazy<IStatisticsService>(() => new StatisticsService(repositoryManager, logger, mapper));

    }

    public IStudentService StudentService => _studentService.Value;
    public ICourseService CourseService => _courseService.Value;
    public IGroupService GroupService => _groupService.Value;
    public IStudentGroupService StudentGroupService => _studentGroupService.Value;
    public IStatisticsService StatisticsService => _statisticsService.Value;
}
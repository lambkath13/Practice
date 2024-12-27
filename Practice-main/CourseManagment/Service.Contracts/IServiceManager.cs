namespace Service;

public interface IServiceManager
{
    IStudentService StudentService { get; }
    ICourseService CourseService { get; }
    IGroupService GroupService { get; }
    IStudentGroupService StudentGroupService { get; }
    IStatisticsService StatisticsService { get; }

}
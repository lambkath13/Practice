namespace Service.Contracts;

public interface IServiceManager
{
    IStudentService StudentService { get; }
    ICourseService CourseService { get; }
    IGroupService GroupService { get; }
}
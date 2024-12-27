using AutoMapper;
using Contracts;
using Shared.StatisticsDTOs;

namespace Service.Statistics;

public sealed class StatisticsService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : IStatisticsService
{

    public StatisticsDto GetStatistics(bool trackChanges)
    {
        var studentCount = repository.Student
            .GetAllStudents(trackChanges)
            .Count();

        var groupCount = repository.Group
            .GetAllGroup(trackChanges)
            .Count();

        var courseCount = repository.Course
            .GetAllCourse(trackChanges)
            .Count();

        return new StatisticsDto
        {
            StudentsCount = studentCount,
            GroupCount = groupCount,
            CourseCount = courseCount
        };
    }
}

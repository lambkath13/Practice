using Shared.StatisticsDTOs;

namespace Service;

public interface IStatisticsService
{
    StatisticsDto GetStatistics(bool trackChanges);
}

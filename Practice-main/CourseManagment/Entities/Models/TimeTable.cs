using Entities.Enums;

namespace Entities.Models;

public class TimeTable
{
    public Guid Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan FromTime { get; set; }
    public TimeSpan ToTime { get; set; }
    public TimeTableType TimeTableType { get; set; }
    public Guid GroupId { get; set; }

    //navigation
    public Group Group { get; set; } = null!;
}
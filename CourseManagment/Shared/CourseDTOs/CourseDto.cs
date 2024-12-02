namespace Shared.CourseDTOs;

public record CourseDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public int NumberOfGroups { get; init; }
    public int NumberOfStudents { get; init; }

}
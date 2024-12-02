namespace Contracts;

public interface IRepositoryManager
{
    IStudentRepository Student { get; }
    ICourseRepository Course { get; }
    IGroupRepository Group { get; }
    void Save();
}
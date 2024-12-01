namespace Contracts;

public interface IRepositoryManager
{
    IStudentRepository Student { get; }
    ICourseRepository Course { get; }
    void Save();
}
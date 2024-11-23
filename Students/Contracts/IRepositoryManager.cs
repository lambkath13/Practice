namespace Contracts;

public interface IRepositoryManager
{
    IStudentRepository Student { get; }
    void Save();
}
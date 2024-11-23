using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IStudentRepository> _studentRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
    }

    public IStudentRepository Student => _studentRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();
}

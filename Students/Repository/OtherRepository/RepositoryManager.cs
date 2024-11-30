using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IStudentRepository> _studentRepository;
    private readonly Lazy<ICourseRepository> _courseRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(repositoryContext));
    }

    public IStudentRepository Student => _studentRepository.Value;
    public ICourseRepository Course => _courseRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();
}

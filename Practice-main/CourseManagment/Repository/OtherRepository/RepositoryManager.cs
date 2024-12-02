﻿using Contracts;
namespace Repository.OtherRepository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IStudentRepository> _studentRepository;
    private readonly Lazy<ICourseRepository> _courseRepository;
    private readonly Lazy<IGroupRepository> _groupRepository;
    

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
        _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(repositoryContext));
        _groupRepository = new Lazy<IGroupRepository>(() => new GroupRepository.GroupRepository(repositoryContext));
    }

    public IStudentRepository Student => _studentRepository.Value;

    public ICourseRepository Course => _courseRepository.Value;

    public IGroupRepository Group => _groupRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();
}
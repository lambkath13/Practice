﻿using Contracts;
using Entities;

namespace Repository;

public class CourseRepository:RepositoryBase<Course>,ICourseRepository
{
    public CourseRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Course> GetAllCourse(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();

    public Course GetCourseById(Guid courseId, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(courseId), trackChanges)
            .SingleOrDefault();

    public void CreateCourse(Course course) => Create(course);

    public void DeleteCourse(Course course) => Delete(course);
}
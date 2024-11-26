using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class CourseConfiguration:IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasData(
            new Course()
            {
                Id = new Guid("b4d4063e-47d6-413c-bc78-2d54a5991370"),
                Name = "Computer Science",
                NumberOfGroups = 2,
                NumberOfStudents = 20
            }
        );
    }
}
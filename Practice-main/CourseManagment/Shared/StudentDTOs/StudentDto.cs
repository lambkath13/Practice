using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Shared.StudentDTOs
{
    public class StudentDto
    {
        public Guid Id { get; set; }

        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string LastName { get; set; }

        public DateTimeOffset BornDate { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? Phone { get; set; }

        public Status Status { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }

    }
}
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Course
{
    [Column]
    public Guid Id { get; set; }

    [MaxLength(250)]
    public required string Name { get; set; }
    [MaxLength(550)]
    public string? SubTitle { get; set; }
    [MaxLength(60)]
    public string? Logo { get; set; }
    public Status Status { get; set; }
    public List<Group> Groups { get; set; } = null!;
}
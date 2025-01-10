using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Position
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    [MaxLength(200)]
    public required string Description { get; set; }
    
}
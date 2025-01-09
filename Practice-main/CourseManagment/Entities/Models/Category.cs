using System.ComponentModel.DataAnnotations;


namespace Entities.Models;

public class Category
{
    public Guid Id { get; set; }

    [MaxLength(250)]
    public required string Name { get; set; }
    [MaxLength(550)]
    public string? Description { get; set; }
    
}
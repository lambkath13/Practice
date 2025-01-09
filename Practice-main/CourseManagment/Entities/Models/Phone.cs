using System.ComponentModel.DataAnnotations;


namespace Entities.Models;

public class Phone
{
    public Guid Id { get; set; }

    [MaxLength(250)]
    public required string Number { get; set; }
    [MaxLength(550)]
    public string? Note { get; set; }
    [MaxLength(60)]
    public Guid UserId { get; set; }
}
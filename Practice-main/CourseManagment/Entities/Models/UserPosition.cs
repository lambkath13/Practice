using Entities.Enums;

namespace Entities.Models;

public class UserPosition
{
    public Guid UserId { get; set; }
    public Guid PositionId { get; set; }
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset FinishedAt { get; set; }
    public Status Status { get; set; }
    
    //navigation
    public User Users { get; set; } = null!;
    public Position Positions { get; set; } = null!;
}
namespace Shared.DataTransferObjects
{
    public record StudentDto{
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public int Age { get; init; }
        public int Course { get; init; }
    }
}
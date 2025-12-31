using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.Positions
{
    public class Position
    {
        public Guid Id { get; }

        public PositionName Name { get; private set; }

        public PositionDescription? Description { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; private set; }
        
        public Position(PositionName name, PositionDescription? description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
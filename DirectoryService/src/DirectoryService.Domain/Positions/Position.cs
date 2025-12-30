namespace DirectoryService.Domain.Positions
{
    public class Position
    {
        public Position(string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                name.Trim().Length < 3 ||
                name.Trim().Length > 100)
            {
                throw new ArgumentException("Name must be between 3 and 150 characters long.");
            }

            if (description != null && description.Trim().Length >= 1000)
            {
                throw new ArgumentException("The description should contain no more than 1000 characters.");
            }

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }

        public string Name { get; private set; }

        public string? Description { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; private set; }
    }
}
namespace DirectoryService.Domain.Locations
{
    public class Location
    {
        public Location(string name, string address, string timezone)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                name.Trim().Length < 3 ||
                name.Trim().Length > 120)
            {
                throw new ArgumentException("Name must be between 3 and 150 characters long.");
            }

            try
            {
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new ArgumentException("Invalid timezone");
            }

            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Timezone = timezone;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public string Timezone { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; private set; }
    }
}
using DirectoryService.Domain.Locations.ValueObjects;

namespace DirectoryService.Domain.Locations
{
    public class Location
    {
        public Guid Id { get; }

        public LocationName Name { get; private set; }

        public LocationAddress Address { get; private set; }

        public LocationTimezone Timezone { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; private set; }
        
        public Location(LocationName name, LocationAddress address, LocationTimezone timezone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            Timezone = timezone;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
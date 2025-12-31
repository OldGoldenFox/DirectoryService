namespace DirectoryService.Domain.Locations.ValueObjects
{
    public record LocationTimezone
    {
        public string Value { get; }

        private LocationTimezone(string value)
        {
            Value = value;
        }

        public static LocationTimezone Create(string value)
        {
            value = value.Trim();
            
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Location timezone cannot be null or whitespace.");
            }
            
            try
            {
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(value);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new ArgumentException("Invalid timezone");
            }
            
            return new LocationTimezone(value);
        }
    }
}
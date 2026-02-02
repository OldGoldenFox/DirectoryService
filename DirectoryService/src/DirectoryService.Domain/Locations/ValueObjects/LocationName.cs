namespace DirectoryService.Domain.Locations.ValueObjects
{
    public record LocationName
    {
        public string Value { get; }
        
        private LocationName(string value)
        {
            Value = value;
        }

        public static LocationName Create(string value)
        {
            value = value.Trim();
            
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Location name cannot be null or whitespace.");
            }
            
            if (value.Length < 3 || value.Length > 120)
            {
                throw new ArgumentException("Location name must be between 3 and 120 characters long.");
            }
            
            return new LocationName(value);
        }
    }
}
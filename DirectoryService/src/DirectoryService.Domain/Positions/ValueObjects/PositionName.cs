namespace DirectoryService.Domain.Positions.ValueObjects
{
    public record PositionName
    {
        public string Value { get; }
        
        private PositionName(string value)
        {
            Value = value;
        }

        public static PositionName Create(string value)
        {
            value = value.Trim();
            
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Department name cannot be null or whitespace.");
            }
            
            if (value.Length < 3 || value.Length > 100)
            {
                throw new ArgumentException("Department name must be between 3 and 100 characters long.");
            }
            
            return new PositionName(value);
        }
    }
}
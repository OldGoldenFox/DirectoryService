namespace DirectoryService.Domain.Positions.ValueObjects
{
    public record PositionDescription
    {
        public string Value { get; }

        private PositionDescription(string value)
        {
            Value = value;
        }

        public static PositionDescription? Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            
            if (value.Trim().Length > 1000)
            {
                throw new ArgumentException("The description should contain no more than 1000 characters.");
            }
            
            return new PositionDescription(value);
        }
    }
}
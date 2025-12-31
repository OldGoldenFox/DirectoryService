namespace DirectoryService.Domain.Departments.ValueObjects
{
    public record DepartmentName
    {
        public string Value { get; }
        
        private DepartmentName(string value)
        {
            Value = value;
        }

        public static DepartmentName Create(string value)
        {
            value = value.Trim();
            
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Department name cannot be null or whitespace.");
            }
            
            if (value.Length < 3 || value.Length > 150)
            {
                throw new ArgumentException("Department name must be between 3 and 150 characters long.");
            }
            
            return new DepartmentName(value);
        }
    }
}
namespace DirectoryService.Domain.Departments.ValueObjects
{
    public record DepartmentPath
    {
        public string Value { get; }
        
        private DepartmentPath(string value)
        {
            Value = value;
        }

        public static DepartmentPath Create(string value)
        {
            value = value.Trim();

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Department path cannot be null or whitespace.");
            }
            
            return new DepartmentPath(value);
        }
    }
}
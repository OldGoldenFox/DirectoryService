namespace DirectoryService.Domain.Departments.ValueObjects
{
    public record DepartmentIdentidier
    {
        public string Value { get; }

        private DepartmentIdentidier(string value)
        {
            Value = value;
        }

        public static DepartmentIdentidier Create(string value)
        {
            value = value.Trim();
            
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Department identifier cannot be null or whitespace.");
            }
            
            if (value.Length < 3 || value.Length > 150)
            {
                throw new ArgumentException("Department identifier must be between 3 and 150 characters long.");
            }

            if (!value.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                throw new ArgumentException("Department identifier must contain only Latin letters.");
            }
            
            return new DepartmentIdentidier(value);
        }
    }
}
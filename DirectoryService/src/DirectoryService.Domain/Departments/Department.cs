namespace DirectoryService.Domain.Departments
{
    public class Department
    {
        public Department(string name, string identifier, Guid? parentId, string path, short depth, IEnumerable<Guid> locationIds)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrWhiteSpace(name) ||
                name.Trim().Length < 3 ||
                name.Trim().Length > 150)
            {
                throw new ArgumentException("Name must be between 3 and 150 characters long.");
            }

            if (string.IsNullOrWhiteSpace(identifier) ||
                identifier.Length < 3 ||
                identifier.Length > 150 ||
                !identifier.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                throw new ArgumentException("Identifier must be between 3 and 150 characters long. And also using the Latin alphabet. ");
            }

            Name = name;
            Identifier = identifier;
            ParentId = parentId;
            Path = path;
            Depth = depth;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            foreach (var locId in locationIds)
            {
                AddLocation(locId);
            }
        }

        public Guid Id { get; }

        public string Name { get; private set; }

        public string Identifier { get; private set; }

        public Guid? ParentId { get; private set; }

        public string Path { get; private set; }

        public short Depth { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; private set; }

        private List<DepartmentLocation> _locations = new List<DepartmentLocation>();

        public IReadOnlyList<DepartmentLocation> Locations => _locations;

        public void AddLocation(Guid locationId)
        {
            _locations.Add(new DepartmentLocation(Guid.NewGuid(), this, locationId));
        }

        private List<DepartmentPosition> _positions = new List<DepartmentPosition>();

        public IReadOnlyList<DepartmentPosition> Positions => _positions;

        public void AddPosition(Guid positionId)
        {
            _positions.Add(new DepartmentPosition(Guid.NewGuid(), this, positionId));
        }
    }
}
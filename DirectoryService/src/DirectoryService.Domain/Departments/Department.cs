using DirectoryService.Domain.Departments.ValueObjects;

namespace DirectoryService.Domain.Departments
{
    public class Department
    {
        private List<DepartmentLocation> _locations = new ();
        
        private List<DepartmentPosition> _positions = new ();

        public Guid Id { get; }

        public DepartmentName Name { get; private set; }

        public DepartmentIdentidier Identifier { get; private set; }

        public Guid? ParentId { get; private set; }

        public DepartmentPath Path { get; private set; }

        public short Depth { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; private set; }
        
        public IReadOnlyList<DepartmentLocation> Locations => _locations;

        public IReadOnlyList<DepartmentPosition> Positions => _positions;
        
        public Department(DepartmentName name, DepartmentIdentidier identifier, Guid? parentId, DepartmentPath path, short depth, IEnumerable<Guid> locationIds)
        {
            Id = Guid.NewGuid();
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
        
        // EF Core
        public Department() { }

        public void AddLocation(Guid locationId)
        {
            _locations.Add(new DepartmentLocation(this, locationId));
        }

        public void AddPosition(Guid positionId)
        {
            _positions.Add(new DepartmentPosition(this, positionId));
        }
    }
}
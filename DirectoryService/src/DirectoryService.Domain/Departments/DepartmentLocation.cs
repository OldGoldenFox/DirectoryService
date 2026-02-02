namespace DirectoryService.Domain.Departments;

public class DepartmentLocation
{
    public Guid Id { get; }

    public Department Department { get; }
    
    public Guid LocationId { get; private set; }

    public DepartmentLocation(Department department, Guid locationId)
    {
        Id = Guid.NewGuid();
        Department = department;
        LocationId = locationId;
    }
    
    // EF Core
    private DepartmentLocation() { }
}
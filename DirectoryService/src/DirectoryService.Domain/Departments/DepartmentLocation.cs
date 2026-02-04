namespace DirectoryService.Domain.Departments;

public class DepartmentLocation
{
    public Guid Id { get; }

    public Guid DepartmentId { get; }
    
    public Guid LocationId { get; private set; }

    public DepartmentLocation(Guid departmentId, Guid locationId)
    {
        Id = Guid.NewGuid();
        DepartmentId = departmentId;
        LocationId = locationId;
    }
    
    // EF Core
    private DepartmentLocation() { }
}
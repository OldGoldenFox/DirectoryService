namespace DirectoryService.Domain.Departments;

public class DepartmentLocation
{
    public Guid Id { get; }

    public Department Department { get; }

    public Guid LocationId { get; private set; }

    public DepartmentLocation(Guid id, Department department, Guid locationId)
    {
        this.Id = id;
        Department = department;
        LocationId = locationId;
    }
}
namespace DirectoryService.Domain.Departments;

public class DepartmentPosition
{
    public Guid Id { get; }

    public Department Department { get; }

    public Guid PositionId { get; private set; }

    public DepartmentPosition(Department department, Guid positionId)
    {
        Id = Guid.NewGuid();
        Department = department;
        PositionId = positionId;
    }
    
    // EF Core
    private DepartmentPosition() { }
}
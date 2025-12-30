namespace DirectoryService.Domain.Departments;

public class DepartmentPosition
{
    public Guid Id { get; }

    public Department Department { get; }

    public Guid PositionId { get; private set; }

    public DepartmentPosition(Guid id, Department department, Guid positionId)
    {
        this.Id = id;
        Department = department;
        PositionId = positionId;
    }
}
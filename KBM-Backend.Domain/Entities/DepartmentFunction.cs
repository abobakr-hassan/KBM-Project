namespace KBM_Backend.Domain.Entities;

public class DepartmentFunction
{
    public Guid DepartmentId { get; set; }

    public Guid FunctionId { get; set; }

    public Department Department { get; set; } = null!;

    public Function Function { get; set; } = null!;
}
namespace KBM_Backend.Domain.Entities;

public class Lesson
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string ProjectName { get; set; } = string.Empty;

    public Guid DepartmentId { get; set; }

    public Guid FunctionId { get; set; }

    public Guid IndustryId { get; set; }

    public string ValueProposition { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string PersonToContact { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    // Relationships

    public Department Department { get; set; } = null!;

    public Function Function { get; set; } = null!;

    public Industry Industry { get; set; } = null!;
}
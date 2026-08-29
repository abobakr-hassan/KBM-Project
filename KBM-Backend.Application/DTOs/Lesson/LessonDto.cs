namespace KBM_Backend.Application.DTOs.Lesson;

public class LessonDto
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
}
namespace KBM_Backend.Domain.Entities;

public class Industry
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public ICollection<Lesson> Lessons { get; set; }
        = new List<Lesson>();
}
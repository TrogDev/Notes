namespace Notes.Domain.Entities;

using Notes.Domain.Common;

public class Note : BaseEntity<long>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string AuthorId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

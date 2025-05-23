using Domain.Enum;
namespace Domain.Entities;

public class Article
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public Status Status { get; set; }
}

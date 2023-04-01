using Postgrest.Attributes;
using Postgrest.Models;

namespace BooksTracker.Models;

[Table("books")]
public class Book : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("image_url")]
    public string ImageUrl { get; set; }

    [Column("author")]
    public string Author { get; set; }

    [Column("created_at", ignoreOnInsert: true)]
    public DateTime CreatedAt { get; set; }

    [Column("is_finished")]
    public bool IsFinished { get; set; }

}

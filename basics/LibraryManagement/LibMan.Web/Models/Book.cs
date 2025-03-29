namespace LibMan.Web.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; } 

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Author { get; set; }

    [Required]
    [StringLength(1000, MinimumLength = 10)]
    public string Description { get; set; }

    [Url]
    public string? ImageUrl { get; set; }

    [Required]
    public Category Category { get; set; }
    
}

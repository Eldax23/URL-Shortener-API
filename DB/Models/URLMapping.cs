namespace urlShortnerApp.DB.Models;

public class URLMapping
{
    public int Id { get; set; }
    public string shortURL { get; set; } = string.Empty;
    public string originalURL { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
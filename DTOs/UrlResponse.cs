namespace urlShortnerApp.DTOs;

public class UrlResponse
{
    public string OriginalUrl { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
}
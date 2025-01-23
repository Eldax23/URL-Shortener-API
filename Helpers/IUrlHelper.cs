namespace urlShortnerApp.Helpers;

public interface IUrlHelper
{
    string ConstructUrl(string shortUrl);
    string GenerateShortUrl();
    bool isValidUrl(string url);
}
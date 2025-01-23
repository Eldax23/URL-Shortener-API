namespace urlShortnerApp.Helpers;

public interface IUrlHelperPersonal
{
    string ConstructUrl(string shortUrl);
    string GenerateShortUrl();
    bool isValidUrl(string url);
}
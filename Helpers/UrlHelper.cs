namespace urlShortnerApp.Helpers;

public class UrlPersonalHelper(IHttpContextAccessor httpContextAccessor) : IUrlHelperPersonal
{
    public string ConstructUrl(string shortUrl)
    {
        var request = httpContextAccessor.HttpContext?.Request;
        string baseUrl = $"{request!.Scheme}://{request.Host}";
        return $"{baseUrl}/{shortUrl}";
    }

    public string GenerateShortUrl()
    {
        return Guid.NewGuid().ToString("n")[..8]; // generates a random code of 8 digits
    }

    public bool isValidUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
            return false;
        
        return Uri.TryCreate(url , UriKind.Absolute , out var uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}
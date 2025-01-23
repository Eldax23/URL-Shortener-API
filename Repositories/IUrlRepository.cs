using urlShortnerApp.DB.Models;

namespace urlShortnerApp.Repositories;

public interface IUrlRepository
{
    Task<URLMapping> GetUrlMappingByShortURLAsync(string shortUrl);
    Task<URLMapping> GetUrlMappingByUrlAsync(string url);
    Task<int> SaveMapping(URLMapping mapping);
}
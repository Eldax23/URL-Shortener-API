using Microsoft.EntityFrameworkCore;
using urlShortnerApp.DB;
using urlShortnerApp.DB.Models;

namespace urlShortnerApp.Repositories;

public class UrlRepository(AppDBContext context) : IUrlRepository
{
    public async Task<URLMapping> GetUrlMappingByShortURLAsync(string shortUrl)
    {
        return await context.URLMappings.FirstOrDefaultAsync(m => m.shortURL == shortUrl) ?? new URLMapping();
    }

    public async Task<URLMapping> GetUrlMappingByUrlAsync(string url)
    {
        return await context.URLMappings.FirstOrDefaultAsync(m => m.originalURL == url) ?? null!;
    }

    public async Task<int> SaveMapping(URLMapping mapping)
    {
        context.URLMappings.Add(mapping);
        return await context.SaveChangesAsync();
    }
}
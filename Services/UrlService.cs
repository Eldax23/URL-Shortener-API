using Microsoft.AspNetCore.Mvc;
using urlShortnerApp.DB.Models;
using urlShortnerApp.Helpers;
using urlShortnerApp.Repositories;

namespace urlShortnerApp.Services;

public class UrlService(IUrlHelperPersonal urlHelper , IUrlRepository urlRepo) : IUrlService
{
    public async Task<string?> ShortenUrlAsync(string originalUrl)
    {
        bool validUrl = urlHelper.isValidUrl(originalUrl);
        if(!validUrl)
            return null!;
        
        URLMapping checkUrl = await urlRepo.GetUrlMappingByUrlAsync(originalUrl);
        if (checkUrl is null) // if the link not shortened before
        {
            string shortCode = urlHelper.GenerateShortUrl();
            URLMapping urlMapping = new URLMapping()
            {
                shortURL = shortCode,
                originalURL = originalUrl,
            };
            
            await urlRepo.SaveMapping(urlMapping); 
            return urlHelper.ConstructUrl(checkUrl!.shortURL);
        }

        return urlHelper.ConstructUrl(checkUrl.shortURL); // no need to save it in DB
    }

    public async Task<string?> GetOriginalUrlAsync(string shortUrl)
    {
        URLMapping urlMapper = await urlRepo.GetUrlMappingByShortURLAsync(shortUrl);
        return urlMapper == null ? null : urlMapper.originalURL;
    }
}
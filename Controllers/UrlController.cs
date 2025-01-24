using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using urlShortnerApp.Services;

namespace urlShortnerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController(IUrlService urlService) : ControllerBase
    {
        [HttpGet("shorten")]
        public async Task<IActionResult> ShortenUrl(string url)
        {
            string? shortUrl = await urlService.ShortenUrlAsync(url);
            if(shortUrl is null)
                return BadRequest("this url is invalid");
            
            return Ok(shortUrl);
        }
        
        
    }
}

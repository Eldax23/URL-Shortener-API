using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using urlShortnerApp.DB;
using urlShortnerApp.Helpers;
using urlShortnerApp.Repositories;
using urlShortnerApp.Services;
using UrlHelper = Microsoft.AspNetCore.Mvc.Routing.UrlHelper;

namespace urlShortnerApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        
        //Add DB Service
        
        builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IUrlRepository, UrlRepository>();
        builder.Services.AddScoped<IUrlHelperPersonal, UrlPersonalHelper>();
        builder.Services.AddScoped<IUrlService, UrlService>();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json" , "v1"));
        }

        app.MapGet("/{shortUrl}", async (string shortUrl, IUrlService urlService) =>
        {
            string result = await urlService.GetOriginalUrlAsync(shortUrl);
            return result == null ? Results.NotFound() : Results.Redirect(result);
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
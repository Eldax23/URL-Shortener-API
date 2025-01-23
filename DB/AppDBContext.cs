using Microsoft.EntityFrameworkCore;
using urlShortnerApp.DB.Models;

namespace urlShortnerApp.DB;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }
    
    public DbSet<URLMapping> URLMappings { get; set; }
}
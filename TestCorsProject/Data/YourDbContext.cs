using Microsoft.EntityFrameworkCore;

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }

    public DbSet<AllowedOrigin> AllowedOrigins { get; set; }
}

public class AllowedOrigin
{
    public int Id { get; set; }
    public string ?Origin { get; set; }
}
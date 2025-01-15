using Microsoft.EntityFrameworkCore;

public class CorsPolicyService : ICorsPolicyService
{
    private readonly YourDbContext _context;

    public CorsPolicyService(YourDbContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetAllowedOriginsAsync()
    {
        return await _context.AllowedOrigins.Select(o => o.Origin).ToListAsync();
    }
}
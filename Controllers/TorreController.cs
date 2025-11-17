using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TorresController : ControllerBase
{
    private readonly AppDbContext _context;

    public TorresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Torre>>> Get()
    {
        return await _context.Torres.ToListAsync();
    }
}


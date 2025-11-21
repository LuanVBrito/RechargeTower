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

    //Get lista de torres
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Torre>>> Get()
    {
        return await _context.Torres.ToListAsync();
    }

    //Post torre
    [HttpPost]
    public async Task<ActionResult> CreateTorre([FromBody] Torre torre)
    {
        if (torre == null)
            return BadRequest("Torre inválida.");
        if (string.IsNullOrEmpty(torre.Nome) || string.IsNullOrEmpty(torre.Localizacao))
                return BadRequest("Nome e Localização são obrigatórios.");
        _context.Torres.Add(torre);
        await _context.SaveChangesAsync();

        return Ok(torre);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Torre UpdatedTorre)
    {
        if (id != UpdatedTorre.Id)
            return BadRequest("Id da torre não corresponde.");

        var torre = await _context.Torres.FindAsync(id);

        if (torre == null)
            return NotFound();

        torre.Nome = updatedTorres.Nome;


    }

}


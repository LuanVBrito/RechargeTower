using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TowerNameController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TowerNameController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetTowerName")]
        public async Task<IActionResult> Get(string nome = null, string localizacao = null)
        {
             // Busca sem critérios - retorna todas as torres
             if (nome == null && localizacao == null)
             {
                 var torres = await _context.Torres.ToListAsync();
                 return Ok(torres);
             }
                // Busca apenas por nome
             if (nome != null && localizacao == null)
             {
                 var tower = await _context.Torres.FirstOrDefaultAsync(t => t.Nome == nome);
                 return tower == null ? NotFound("Torre não encontrada") : Ok(tower);
             }
              // Busca por nome e localizacao
             if (nome != null && localizacao != null)
             {
                 var tower = await _context.Torres.FirstOrDefaultAsync(t => t.Nome == nome && t.Localizacao == localizacao);
                 return tower == null ? NotFound("Torre não encontrada") : Ok(tower);
             }
                 return BadRequest("Torre inválida");
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tower torre)
        {
            try
            {
                if (torre == null)
                    return BadRequest("Dados da torre inválidos");

                // Validação básica
                if (string.IsNullOrWhiteSpace(torre.Nome))
                    return BadRequest("Nome da torre é obrigatório");

                if (string.IsNullOrWhiteSpace(torre.Localizacao))
                    return BadRequest("Localização da torre é obrigatória");

                // Verificar se já existe uma torre com o mesmo nome
                var torreExistente = await _context.Torres
                    .FirstOrDefaultAsync(t => t.Nome == torre.Nome);

                if (torreExistente != null)
                    return Conflict("Já existe uma torre com este nome");

                _context.Torres.Add(torre);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { nome = torre.Nome }, torre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao criar torre: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("ID da torre é obrigatório e deve ser maior que zero");

                var torre = await _context.Torres
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (torre == null)
                    return NotFound("Torre não encontrada");

                _context.Torres.Remove(torre);
                await _context.SaveChangesAsync();

                return Ok($"Torre com ID {id} removida com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao remover torre: {ex.Message}");
            }
        }
    }
}
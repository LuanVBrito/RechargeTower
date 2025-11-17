using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RechargeTowerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RechargeTowerController(AppDbContext context)
        {
            _context = context;
        }

        // GET /user?email=...&password=...
        [HttpGet(Name = "GetRechargeTower")]
        public async Task<IActionResult> Get(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user == null)
                return NotFound("Usuário não encontrado.");

            return Ok(user);
        }

        // POST /user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Usuário inválido.");

            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Email e senha são obrigatórios.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        //PUt
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User updatedUser)
        {
            if (id != updatedUser.Id)
                return BadRequest("Id do usuário não corresponde.");

                var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Delete
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}


using c_sharp_odontoprev.Data;
using c_sharp_odontoprev.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_odontoprev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginDto>>> GetAllLogins()
        {
            var logins = await _context.Logins
                .Select(l => new LoginDto
                {
                    Id = l.ID,
                    Email = l.EMAIL,
                    Senha = l.SENHA
                })
                .ToListAsync();

            return Ok(logins);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoginDto>> GetLoginById(int id)
        {
            var login = await _context.Logins
                .Where(l => l.ID == id)
                .Select(l => new LoginDto
                {
                    Id = l.ID,
                    Email = l.EMAIL,
                    Senha = l.SENHA
                })
                .FirstOrDefaultAsync();

            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }
    }
}


using c_sharp_odontoprev.Data;
using c_sharp_odontoprev.DTOs;
using c_sharp_odontoprev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_odontoprev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DentistaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DentistaDto>>> GetDentistas()
        {
            var dentistas = await _context.Dentistas
                .Select(d => new DentistaDto
                {
                    ID = d.ID,
                    Nome = d.Nome,
                    DataNascimento = d.DataNascimento,
                    Email = d.Email,
                    Cpf = d.Cpf,
                    Telefone = d.Telefone,
                    CRO = d.CRO,
                    IdGenero = d.IdGenero,
                    IdEndereco = d.IdEndereco,
                    IdLogin = d.IdLogin,
                    DentistaSuspeito = d.DentistaSuspeito
                })
                .ToListAsync();

            return Ok(dentistas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DentistaDto>> GetDentista(int id)
        {
            var dentista = await _context.Dentistas
                .Where(d => d.ID == id)
                .FirstOrDefaultAsync();

            if (dentista == null)
            {
                return NotFound();
            }

            var dentistaDto = new DentistaDto
            {
                ID = dentista.ID,
                Nome = dentista.Nome,
                DataNascimento = dentista.DataNascimento,
                Email = dentista.Email,
                Cpf = dentista.Cpf,
                Telefone = dentista.Telefone,
                CRO = dentista.CRO,
                IdGenero = dentista.IdGenero,  
                IdEndereco = dentista.IdEndereco,
                IdLogin = dentista.IdLogin,
                DentistaSuspeito = dentista.DentistaSuspeito
            };

            return Ok(dentistaDto);
        }

        [HttpPost]
        public async Task<ActionResult<Dentista>> PostDentista(DentistaDto dentistaDto)
        {
            var dentista = new Dentista
            {
                Nome = dentistaDto.Nome,
                DataNascimento = dentistaDto.DataNascimento,
                Email = dentistaDto.Email,
                Cpf = dentistaDto.Cpf,
                Telefone = dentistaDto.Telefone,
                CRO = dentistaDto.CRO,
                IdGenero = dentistaDto.IdGenero, 
                IdEndereco = dentistaDto.IdEndereco,
                IdLogin = dentistaDto.IdLogin,
                DentistaSuspeito = dentistaDto.DentistaSuspeito
            };

            _context.Dentistas.Add(dentista);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDentista), new { id = dentista.ID }, dentista);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDentista(int id, DentistaDto dentistaDto)
        {
            if (id != dentistaDto.ID)
            {
                return BadRequest();
            }

            var dentista = await _context.Dentistas.FindAsync(id);

            if (dentista == null)
            {
                return NotFound();
            }

            dentista.Nome = dentistaDto.Nome;
            dentista.DataNascimento = dentistaDto.DataNascimento;
            dentista.Email = dentistaDto.Email;
            dentista.Cpf = dentistaDto.Cpf;
            dentista.Telefone = dentistaDto.Telefone;
            dentista.CRO = dentistaDto.CRO;
            dentista.IdGenero = dentistaDto.IdGenero; 
            dentista.IdEndereco = dentistaDto.IdEndereco;
            dentista.IdLogin = dentistaDto.IdLogin;
            dentista.DentistaSuspeito = dentistaDto.DentistaSuspeito;

            _context.Entry(dentista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DentistaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDentista(int id)
        {
            var dentista = await _context.Dentistas.FindAsync(id);
            if (dentista == null)
            {
                return NotFound();
            }

            _context.Dentistas.Remove(dentista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DentistaExists(int id)
        {
            return _context.Dentistas.Any(e => e.ID == id);
        }
    }
}

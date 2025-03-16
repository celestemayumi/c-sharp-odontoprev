using c_sharp_odontoprev.Data;
using c_sharp_odontoprev.DTOs;
using c_sharp_odontoprev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_odontoprev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDto>>> GetPacientes()
        {
            var pacientes = await _context.Pacientes
                .Select(p => new PacienteDto
                {
                    Id = p.ID,
                    Nome = p.Nome,
                    DataNascimento = p.DataNascimento,
                    Email = p.Email,
                    Cpf = p.Cpf,
                    Telefone = p.Telefone,
                    IdGenero = p.IdGenero,
                    IdEndereco = p.IdEndereco,
                    IdLogin = p.IdLogin,
                    ClienteSuspeito = p.ClienteSuspeito
                })
                .ToListAsync();

            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDto>> GetPaciente(int id)
        {
            var paciente = await _context.Pacientes
                .Where(p => p.ID == id)
                .FirstOrDefaultAsync();

            if (paciente == null)
            {
                return NotFound();
            }

            var pacienteDto = new PacienteDto
            {
                Id = paciente.ID,
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento,
                Email = paciente.Email,
                Cpf = paciente.Cpf,
                Telefone = paciente.Telefone,
                IdGenero = paciente.IdGenero,
                IdEndereco = paciente.IdEndereco,
                IdLogin = paciente.IdLogin,
                ClienteSuspeito = paciente.ClienteSuspeito
            };

            return Ok(pacienteDto);
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(PacienteDto pacienteDto)
        {
            var paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                DataNascimento = pacienteDto.DataNascimento,
                Email = pacienteDto.Email,
                Cpf = pacienteDto.Cpf,
                Telefone = pacienteDto.Telefone,
                IdGenero = pacienteDto.IdGenero, 
                IdEndereco = pacienteDto.IdEndereco,
                IdLogin = pacienteDto.IdLogin,
                ClienteSuspeito = pacienteDto.ClienteSuspeito
            };

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.ID }, paciente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, PacienteDto pacienteDto)
        {
            if (id != pacienteDto.Id)
            {
                return BadRequest();
            }

            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }
            paciente.Nome = pacienteDto.Nome;
            paciente.DataNascimento = pacienteDto.DataNascimento;
            paciente.Email = pacienteDto.Email;
            paciente.Cpf = pacienteDto.Cpf;
            paciente.Telefone = pacienteDto.Telefone;
            paciente.IdGenero = pacienteDto.IdGenero; 
            paciente.IdEndereco = pacienteDto.IdEndereco;
            paciente.IdLogin = pacienteDto.IdLogin;
            paciente.ClienteSuspeito = pacienteDto.ClienteSuspeito;

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.ID == id);
        }
    }
}

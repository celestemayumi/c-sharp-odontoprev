using c_sharp_odontoprev.Data;
using c_sharp_odontoprev.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace c_sharp_odontoprev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsultaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaDTO>>> GetConsultas()
        {
            var consultas = await _context.Consultas
                .Include(c => c.Paciente)  
                .Include(c => c.Dentista)   
                .Include(c => c.Unidade)  
                .Select(c => new ConsultaDTO
                {
                    ID = c.ID,
                    DATA_CONSULTA = c.DATA_CONSULTA,
                    IdPaciente = c.IdPaciente,
                    IdDentista = c.IdDentista,
                    IdUnidade = c.IdUnidade
                })
                .ToListAsync();

            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaDTO>> GetConsultaById(int id)
        {
            var consulta = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Dentista)
                .Include(c => c.Unidade)
                .Where(c => c.ID == id)
                .Select(c => new ConsultaDTO
                {
                    ID = c.ID,
                    DATA_CONSULTA = c.DATA_CONSULTA,
                    IdPaciente = c.IdPaciente,
                    IdDentista = c.IdDentista,
                    IdUnidade = c.IdUnidade
                })
                .FirstOrDefaultAsync();

            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta); 
        }
    }
}

using c_sharp_odontoprev.DTOs;
using c_sharp_odontoprev.Models;
using c_sharp_odontoprev.Services;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_odontoprev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly IService<Cidade> _cidadeService;

        public CidadeController(IService<Cidade> cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CidadeDto>>> GetCidades()
        {
            var cidades = await _cidadeService.GetAllAsync();
            var cidadesDTO = cidades.Select(c => new CidadeDto
            {
                Id = c.ID,
                Nome = c.Nome,
                IdEstado = c.IdEstado
            });

            return Ok(cidadesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CidadeDto>> GetCidade(int id)
        {
            var cidade = await _cidadeService.GetByIdAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }

            var cidadeDTO = new CidadeDto
            {
                Id = cidade.ID,
                Nome = cidade.Nome,
                IdEstado = cidade.IdEstado
            };

            return Ok(cidadeDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CidadeDto>> PostCidade(CidadeDto cidadeDTO)
        {
            var cidade = new Cidade
            {
                Nome = cidadeDTO.Nome,
                IdEstado = cidadeDTO.IdEstado
            };

            await _cidadeService.AddAsync(cidade);

            cidadeDTO.Id = cidade.ID;

            return CreatedAtAction(nameof(GetCidade), new { id = cidadeDTO.Id }, cidadeDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCidade(int id, CidadeDto cidadeDTO)
        {
            var cidade = await _cidadeService.GetByIdAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }

            cidade.Nome = cidadeDTO.Nome;
            cidade.IdEstado = cidadeDTO.IdEstado;

            await _cidadeService.UpdateAsync(cidade);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidade(int id)
        {
            var cidade = await _cidadeService.GetByIdAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            await _cidadeService.DeleteAsync(id);

            return NoContent();
        }
    }
}

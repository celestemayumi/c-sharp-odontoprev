using c_sharp_odontoprev.DTOs;
using c_sharp_odontoprev.Models;
using c_sharp_odontoprev.Services;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_odontoprev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BairroController : ControllerBase
    {
        private readonly IService<Bairro> _bairroService;

        public BairroController(IService<Bairro> bairroService)
        {
            _bairroService = bairroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BairroDto>>> GetBairros()
        {
            var bairros = await _bairroService.GetAllAsync();
            var bairrosDTO = bairros.Select(b => new BairroDto
            {
                Id = b.ID,
                Nome = b.Nome,
                IdCidade = b.IdCidade
            });

            return Ok(bairrosDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BairroDto>> GetBairro(int id)
        {
            var bairro = await _bairroService.GetByIdAsync(id);
            if (bairro == null)
            {
                return NotFound();
            }

            var bairroDTO = new BairroDto
            {
                Id = bairro.ID,
                Nome = bairro.Nome,
                IdCidade = bairro.IdCidade
            };

            return Ok(bairroDTO);
        }

        [HttpPost]
        public async Task<ActionResult<BairroDto>> PostBairro(BairroDto bairroDTO)
        {
            var bairro = new Bairro
            {
                Nome = bairroDTO.Nome,
                IdCidade = bairroDTO.IdCidade
            };

            await _bairroService.AddAsync(bairro);

            bairroDTO.Id = bairro.ID;

            return CreatedAtAction(nameof(GetBairro), new { id = bairroDTO.Id }, bairroDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBairro(int id, BairroDto bairroDTO)
        {
            var bairro = await _bairroService.GetByIdAsync(id);
            if (bairro == null)
            {
                return NotFound();
            }

            bairro.Nome = bairroDTO.Nome;
            bairro.IdCidade = bairroDTO.IdCidade;

            await _bairroService.UpdateAsync(bairro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBairro(int id)
        {
            var bairro = await _bairroService.GetByIdAsync(id);
            if (bairro == null)
            {
                return NotFound();
            }
            await _bairroService.DeleteAsync(id);

            return NoContent();
        }
    }
}

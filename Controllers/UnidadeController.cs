using c_sharp_odontoprev.DTOs;
using c_sharp_odontoprev.Models;
using c_sharp_odontoprev.Services;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_odontoprev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly IService<Unidade> _unidadeService;

        public UnidadeController(IService<Unidade> unidadeService)
        {
            _unidadeService = unidadeService;
        }

        // GET: api/Unidade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeDto>>> GetUnidades()
        {
            var unidades = await _unidadeService.GetAllAsync();
            var unidadesDTO = unidades.Select(u => new UnidadeDto
            {
                Id = u.ID,
                Nome = u.Nome,
                Telefone = u.Telefone,
                IdEndereco = u.IdEndereco
            });

            return Ok(unidadesDTO);
        }

        // GET: api/Unidade/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeDto>> GetUnidade(int id)
        {
            var unidade = await _unidadeService.GetByIdAsync(id);
            if (unidade == null)
            {
                return NotFound();
            }

            var unidadeDTO = new UnidadeDto
            {
                Id = unidade.ID,
                Nome = unidade.Nome,
                Telefone = unidade.Telefone,
                IdEndereco = unidade.IdEndereco
            };

            return Ok(unidadeDTO);
        }

        // POST: api/Unidade
        [HttpPost]
        public async Task<ActionResult<UnidadeDto>> PostUnidade(UnidadeDto unidadeDTO)
        {
            var unidade = new Unidade
            {
                Nome = unidadeDTO.Nome,
                Telefone = unidadeDTO.Telefone,
                IdEndereco = unidadeDTO.IdEndereco
            };

            await _unidadeService.AddAsync(unidade);

            unidadeDTO.Id = unidade.ID;

            return CreatedAtAction(nameof(GetUnidade), new { id = unidadeDTO.Id }, unidadeDTO);
        }

        // PUT: api/Unidade/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidade(int id, UnidadeDto unidadeDTO)
        {
            var unidade = await _unidadeService.GetByIdAsync(id);
            if (unidade == null)
            {
                return NotFound();
            }

            unidade.Nome = unidadeDTO.Nome;
            unidade.Telefone = unidadeDTO.Telefone;
            unidade.IdEndereco = unidadeDTO.IdEndereco;

            await _unidadeService.UpdateAsync(unidade);
            return NoContent();
        }

        // DELETE: api/Unidade/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidade(int id)
        {
            var unidade = await _unidadeService.GetByIdAsync(id);
            if (unidade == null)
            {
                return NotFound();
            }

            await _unidadeService.DeleteAsync(id);
            return NoContent();
        }
    }
}

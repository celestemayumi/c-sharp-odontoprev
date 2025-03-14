using c_sharp_odontoprev.DTOs;
using c_sharp_odontoprev.Models;
using c_sharp_odontoprev.Services;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_odontoprev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IService<Endereco> _enderecoService;

        public EnderecoController(IService<Endereco> enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDto>>> GetEnderecos()
        {
            var enderecos = await _enderecoService.GetAllAsync();
            var enderecosDTO = enderecos.Select(e => new EnderecoDto
            {
                Id = e.ID,
                Logradouro = e.Logradouro,
                Numero = e.Numero,
                Cep = e.Cep,
                Complemento = e.Complemento,
                IdBairro = e.IdBairro
            });

            return Ok(enderecosDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoDto>> GetEndereco(int id)
        {
            var endereco = await _enderecoService.GetByIdAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            var enderecoDTO = new EnderecoDto
            {
                Id = endereco.ID,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Cep = endereco.Cep,
                Complemento = endereco.Complemento,
                IdBairro = endereco.IdBairro
            };

            return Ok(enderecoDTO);
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoDto>> PostEndereco(EnderecoDto enderecoDTO)
        {
            var endereco = new Endereco
            {
                Logradouro = enderecoDTO.Logradouro,
                Numero = enderecoDTO.Numero,
                Cep = enderecoDTO.Cep,
                Complemento = enderecoDTO.Complemento,
                IdBairro = enderecoDTO.IdBairro
            };

            await _enderecoService.AddAsync(endereco);

            enderecoDTO.Id = endereco.ID;

            return CreatedAtAction(nameof(GetEndereco), new { id = enderecoDTO.Id }, enderecoDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, EnderecoDto enderecoDTO)
        {
            var endereco = await _enderecoService.GetByIdAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            endereco.Logradouro = enderecoDTO.Logradouro;
            endereco.Numero = enderecoDTO.Numero;
            endereco.Cep = enderecoDTO.Cep;
            endereco.Complemento = enderecoDTO.Complemento;
            endereco.IdBairro = enderecoDTO.IdBairro;

            await _enderecoService.UpdateAsync(endereco);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _enderecoService.GetByIdAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            await _enderecoService.DeleteAsync(id);
            return NoContent();
        }
    }
}


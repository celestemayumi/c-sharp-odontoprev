using c_sharp_odontoprev.DTOs;
using c_sharp_odontoprev.Models;
using c_sharp_odontoprev.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EstadoController : ControllerBase
{
    private readonly IService<Estado> _service;

    public EstadoController(IService<Estado> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var estados = await _service.GetAllAsync();
        var dtos = estados.Select(e => new EstadoDto
        {
            Id = e.ID,
            Nome = e.Nome,
            Sigla = e.Sigla
        });

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var estado = await _service.GetByIdAsync(id);
        if (estado == null) return NotFound();

        var dto = new EstadoDto
        {
            Id = estado.ID,
            Nome = estado.Nome,
            Sigla = estado.Sigla
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EstadoDto dto)
    {
        var estado = new Estado
        {
            ID = dto.Id,
            Nome = dto.Nome,
            Sigla = dto.Sigla
        };

        await _service.AddAsync(estado);
        return CreatedAtAction(nameof(GetById), new { id = estado.ID }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EstadoDto dto)
    {
        if (id != dto.Id) return BadRequest();

        var estado = new Estado
        {
            ID = dto.Id,
            Nome = dto.Nome,
            Sigla = dto.Sigla
        };

        await _service.UpdateAsync(estado);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

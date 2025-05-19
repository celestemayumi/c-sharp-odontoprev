using c_sharp_odontoprev.Models;
using c_sharp_odontoprev.Services;
using Microsoft.AspNetCore.Mvc;

namespace c_sharp_odontoprev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasMLController : ControllerBase
    {
        private readonly MLService _mlService;

        public ConsultasMLController(MLService mlService)
        {
            _mlService = mlService;
        }
        
        [HttpPost("treinar")]
        public IActionResult Treinar()
        {
            _mlService.TreinarModelo();
            return Ok(new { mensagem = "Modelo treinado com sucesso!" });
        }

        [HttpPost("prever-falta")]
        public IActionResult PreverFalta([FromBody] InputML input)
        {
            var resultado = _mlService.Prever(input);
            return Ok(resultado);
        }
    }
}

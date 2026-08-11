using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PredFix.Applications.Services;
using PredFix.DTOs.InspecaoDto;
using PredFix.Exceptions;

namespace PredFix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspecaoController : ControllerBase
    {
        private readonly InspecaoService _service;

        public InspecaoController(InspecaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerInspecaoDto>> Listar()
        {
            List<LerInspecaoDto> inspecoes = _service.Listar();
            return Ok(inspecoes);
        }

        [HttpGet("{id}")]
        public ActionResult<LerInspecaoDto> ObterPorId(int id)
        {
            try
            {
                var inspecao = _service.ObterPorId(id);
          
                return Ok(inspecao);
            }
            catch (DomainException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet("{id}/audio")]
        public IActionResult ObterAudio(int id)
        {
            try
            {
                byte[] audioBytes = _service.ObterAudio(id);
                return File(audioBytes, "audio/mp4");
            }
            catch (DomainException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<LerInspecaoDto> Adicionar([FromForm] CriarInspecaoDto inspecaoDto)
        {
            try
            {
                var inspecaoCriada = _service.Adicionar(inspecaoDto);
                return StatusCode(201, inspecaoCriada);
            }
            catch (DomainException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}

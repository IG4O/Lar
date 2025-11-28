using Microsoft.AspNetCore.Mvc;
using ProjetoLar.src.DTOs.PessoaDTO;
using ProjetoLar.src.Services;

namespace ProjetoLar.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _service;
        public PessoasController(IPessoaService service) => _service = service;


        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAll());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _service.GetById(id);
            if (p == null) return NotFound();
            return Ok(p);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreatePessoaDTO dto)
        {
            var created = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePessoaDTO dto)
        {
            await _service.Update(id, dto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}

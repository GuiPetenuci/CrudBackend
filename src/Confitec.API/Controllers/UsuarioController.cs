using Confitec.Application.Interfaces.Services;
using Confitec.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.API;

[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("usuarios")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _usuarioService.GetAll());
        }
        catch
        {
            return StatusCode(500, "Erro interno");
        }
    }

    [HttpGet("usuarios/{id:guid}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        try
        {
            var usuario = await _usuarioService.GetById(id);

            if (usuario is null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }
        catch
        {
            return StatusCode(500, "Erro interno");
        }
    }

    [HttpPost("usuarios")]
    public async Task<IActionResult> PostAsync(
        [FromBody] UsuarioViewModel model)
    {
        model.Id = null;
        if (!ModelState.IsValid)
            return BadRequest(ModelState.Values.Select(c => c.Errors.Select(x => x.ErrorMessage)));
        try
        {
            await _usuarioService.Add(model);
            return Created();
        }
        catch
        {
            return StatusCode(500, "Erro interno");
        }
    }

    [HttpPut("usuarios/{id:guid}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] Guid id,
        [FromBody] UsuarioViewModel model)
    {
        try
        {
            var usuario = await _usuarioService.GetById(id);

            if (usuario is null)
                return NotFound("Usuário não encontrado.");

            model.Id = id;

            await _usuarioService.Update(model);

            return Ok();
        }
        catch
        {
            return StatusCode(500, "Erro interno");
        }
    }

    [HttpDelete("usuarios/{id:guid}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] Guid id)
    {
        try
        {
            var usuario = await _usuarioService.GetById(id);

            if (usuario is null)
                return NotFound("Usuário não encontrado.");

            await _usuarioService.Remove(id);

            return Ok();
        }
        catch
        {
            return StatusCode(500, "Erro interno");
        }
    }
}

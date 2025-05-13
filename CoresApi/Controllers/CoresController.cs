using CoresBusiness;
using CoresModel;
using Microsoft.AspNetCore.Mvc;

namespace CoresApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoresController
(
    CorService corService
) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var cores = corService.ListarTodos();
        return cores.Count == 0 ? NoContent() : Ok(cores);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var cor = corService.ObterPorId(id);
        return cor == null ? NotFound() : Ok(cor);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CorModel cor)
    {
        if (string.IsNullOrWhiteSpace(cor.Cor))
            return BadRequest("Cor é obrigatória.");
        var criado = corService.Criar(cor);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CorModel cor)
    {
        if (cor == null || cor.Id != id)
            return BadRequest("Dados inconsistentes.");
        return corService.Atualizar(cor) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return corService.Remover(id) ? NoContent() : NotFound();
    }
}

internal class CorService
{
    internal object ListarTodos()
    {
        throw new NotImplementedException();
    }
}

public class CorModel
{
    public int Id { get; internal set; }
}
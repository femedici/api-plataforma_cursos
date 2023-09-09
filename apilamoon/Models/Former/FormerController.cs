using MainProfiles.Models;
using MainProfiles.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class FormerController : ControllerBase
{
    public FormerController()
    {
    }

    //Faz a consulta de todos os Usuarios cadastrados
    [HttpGet]
    public ActionResult<List<Former>> GetAll() =>
        FormerService.GetAll();

    [HttpGet("{id}")]

    //Faz a consulta de apenas 1 usuário, com o cpf
    public ActionResult<Former> Get(int id)
    {
        var former = FormerService.Get(id);

        if (former == null)
            return NotFound();

        return former;
    }

    // POST action - Criar CRUD
    [HttpPost]
    public IActionResult Create(Former former)
    {
        FormerService.Add(former);
        return CreatedAtAction(nameof(Get), new { id = former.id }, former);
    }

    // PUT action - Atualizar CRUD
    [HttpPut("{id}")]
    public IActionResult Update(int id, Former former)
    {
        if (id != former.id)
            return BadRequest();
        var existingformer = FormerService.Get(id);

        if (existingformer is null)
            return NotFound();

        FormerService.Update(former);

        return NoContent();
    }

    // DELETE action - Excluir CRUD
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var former = FormerService.Get(id);

        if (former is null)
            return NotFound();

        FormerService.Delete(id);

        return NoContent();
    }

}
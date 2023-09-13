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

    [HttpGet("{Cpf}")]

    //Faz a consulta de apenas 1 usuário, com o cpf
    public ActionResult<Former> Get(string Cpf)
    {
        var former = FormerService.Get(Cpf);

        if (former == null)
            return NotFound();

        return former;
    }

    // POST action - Criar CRUD
    [HttpPost]
    public IActionResult Create(Former former)
    {
        FormerService.Add(former);
        return CreatedAtAction(nameof(Get), new { id = former.Id }, former);
    }

    // PUT action - Atualizar CRUD
    [HttpPut("{Cpf}")]
    public IActionResult Update(string Cpf, Former former)
    {
        if (Cpf != former.Cpf)
            return BadRequest();
        var existingformer = FormerService.Get(Cpf);

        if (existingformer is null)
            return NotFound();

        FormerService.Update(former);

        return NoContent();
    }

    // DELETE action - Excluir CRUD
    [HttpDelete("{Cpf}")]
    public IActionResult Delete(string Cpf)
    {
        var former = FormerService.Get(Cpf);

        if (former is null)
            return NotFound();

        FormerService.Delete(Cpf);

        return NoContent();
    }

}
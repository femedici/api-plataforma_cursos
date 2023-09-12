using MainProfiles.Models;
using MainProfiles.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    public AdminController()
    {
    }

    //Faz a consulta de todos os Usuarios cadastrados
    [HttpGet]
    public ActionResult<List<Admin>> GetAll() =>
        AdminService.GetAll();

    [HttpGet("{id}")]

    //Faz a consulta de apenas 1 usuário, com o cpf
    public ActionResult<Admin> Get(int id)
    {
        var admin = AdminService.Get(id);

        if (admin == null)
            return NotFound();

        return admin;
    }

    // POST action - Criar CRUD
    [HttpPost]
    public IActionResult Create(Admin admin)
    {
        AdminService.Add(admin);
        return CreatedAtAction(nameof(Get), new { id = admin.Id }, admin);
    }

    // PUT action - Atualizar CRUD
    [HttpPut("{id}")]
    public IActionResult Update(int id, Admin admin)
    {
        if (id != admin.Id)
            return BadRequest();
        var existingadmin = AdminService.Get(id);

        if (existingadmin is null)
            return NotFound();

        AdminService.Update(admin);

        return NoContent();
    }

    // DELETE action - Excluir CRUD
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var admin = AdminService.Get(id);

        if (admin is null)
            return NotFound();

        AdminService.Delete(id);

        return NoContent();
    }

}
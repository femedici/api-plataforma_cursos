using MainProfiles.Models;
using MainProfiles.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
    }

    //Faz a consulta de todos os Usuarios cadastrados
    [HttpGet]
    public ActionResult<List<User>> GetAll() =>
        UserService.GetAll();

    [HttpGet("{Cpf}")]

    //Faz a consulta de apenas 1 usuário, com o cpf
    public ActionResult<User> Get(string Cpf)
    {
        var user = UserService.Get(Cpf);

        if (user == null)
            return NotFound();

        return user;
    }

    // POST action - Criar CRUD
    [HttpPost]
    public IActionResult Create(User user)
    {
        UserService.Add(user);
        return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);
    }

    // PUT action - Atualizar CRUD
    [HttpPut("{Cpf}")]
    public IActionResult Update(string Cpf, User user)
    {
        if (Cpf != user.Cpf)
            return BadRequest();
        var existingUser = UserService.Get(Cpf);

        if (existingUser is null)
            return NotFound();

        UserService.Update(user);

        return NoContent();
    }

    // DELETE action - Excluir CRUD
    [HttpDelete("{Cpf}")]
    public IActionResult Delete(string Cpf)
    {
        var user = UserService.Get(Cpf);

        if (user is null)
            return NotFound();

        UserService.Delete(Cpf);

        return NoContent();
    }

}
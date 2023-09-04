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

    [HttpGet("{id}")]

    //Faz a consulta de apenas 1 usuário, com o cpf
    public ActionResult<User> Get(int id)
    {
        var user = UserService.Get(id);

        if (user == null)
            return NotFound();

        return user;
    }

    // POST action - Criar CRUD
    [HttpPost]
    public IActionResult Create(User user)
    {
        UserService.Add(user);
        return CreatedAtAction(nameof(Get), new { id = user.id }, user);
    }

    // PUT action - Atualizar CRUD
    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        if (id != user.id)
            return BadRequest();
        var existingUser = UserService.Get(id);

        if (existingUser is null)
            return NotFound();

        UserService.Update(user);

        return NoContent();
    }

    // DELETE action - Excluir CRUD
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = UserService.Get(id);

        if (user is null)
            return NotFound();

        UserService.Delete(id);

        return NoContent();
    }

}
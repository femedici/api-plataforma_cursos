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

    [HttpGet("{Id}")]

    //Faz a consulta de apenas 1 usuário, com o cpf
    public ActionResult<User> Get(int Id)
    {
        var user = UserService.Get(Id);

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
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, User user)
    {
        if (Id != user.Id)
            return BadRequest();
        var existingUser = UserService.Get(Id);

        if (existingUser is null)
            return NotFound();

        UserService.Update(user);

        return NoContent();
    }

    // DELETE action - Excluir CRUD
    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id)
    {
        var user = UserService.Get(Id);

        if (user is null)
            return NotFound();

        UserService.Delete(Id);

        return NoContent();
    }

}
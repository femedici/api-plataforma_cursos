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
    public ActionResult<User> Get(string cpf)
    {
        var user = UserService.Get(cpf);

        if (user == null)
            return NotFound();

        return user;
    }

    // POST action
    // [HttpPost]
    // public IActionResult Create(User user)
    // {
    //     // This code will save the pizza and return a result
    // }

    // PUT action

    // DELETE action
}
using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    IMongoCollection<User> _users;
    public UserController(MeuMongo meuMongo)
    {
        _users = meuMongo.DB.GetCollection<User>("users");
    }

    //Faz a consulta de todos os Usuarios cadastrados
    [HttpGet]
    public IActionResult Get()
    {
        var users = _users.AsQueryable().ToList();
        return Ok(users);
    }

    [HttpPost]
    public IActionResult Post(User user)
    {

        _users.InsertOne(user);
        return Ok();
    }

    //Faz a consulta de apenas 1 usuário, com o id
    [HttpGet("id/{id}")]
    public ActionResult<User> GetById(int id)
    {
        var user = _users.Find(User => User.Id == id).FirstOrDefault();
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }


    //Faz a consulta de apenas 1 usuário, com o email
    [HttpGet("email/{email}")]
    public ActionResult<User> GetByEmail(string email)
    {
        var user = _users.Find(User => User.Email == email).FirstOrDefault();
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }


    //Altera a senha do usuario pelo Id
    [HttpPut("{id}")]
    public IActionResult ChangePasswordById(int id, [FromBody] string newPassword)
    {
        // Verifique se o usuário com o id especificado existe
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        var user = _users.Find(filter).FirstOrDefault();

        if (user == null)
        {
            return NotFound();
        }

        // Atualize a senha do usuário
        var update = Builders<User>.Update
            .Set(u => u.Password, newPassword);

        var updateResult = _users.UpdateOne(filter, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
    }

    // Deleta por id
    [HttpDelete("{id}")]
    public IActionResult DeleteByCpf(int id)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        var deleteResult = _users.DeleteOne(filter);

        if (deleteResult.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

}
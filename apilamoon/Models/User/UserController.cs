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

    [HttpGet("cpf/{cpf}")]
    //Faz a consulta de apenas 1 usuário, com o cpf
    public ActionResult<User> GetByCpf(string cpf)
    {
        var user = _users.Find(User => User.Cpf == cpf).FirstOrDefault();
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet("email/{email}")]
    //Faz a consulta de apenas 1 usuário, com o cpf
    public ActionResult<User> GetByEmail(string email)
    {
        var user = _users.Find(User => User.Email == email).FirstOrDefault();
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPut("{cpf}")]
    public IActionResult PutByCpf(string cpf, User updatedUser)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Cpf, cpf);
        var update = Builders<User>.Update
            .Set(u => u.Name, updatedUser.Name)
            .Set(u => u.Email, updatedUser.Email)
            .Set(u => u.Password, updatedUser.Password);

        var updateResult = _users.UpdateOne(filter, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
    }

    // HTTP DELETE por CPF
    [HttpDelete("{cpf}")]
    public IActionResult DeleteByCpf(string cpf)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Cpf, cpf);
        var deleteResult = _users.DeleteOne(filter);

        if (deleteResult.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

}
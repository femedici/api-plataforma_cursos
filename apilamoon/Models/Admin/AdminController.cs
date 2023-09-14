using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    IMongoCollection<Admin> _admins;
    public AdminController(MeuMongo meuMongo)
    {
        _admins = meuMongo.DB.GetCollection<Admin>("admins");
    }

    //Faz a consulta de todos os Usuarios cadastrados
    [HttpGet]
    public IActionResult Get()
    {
        var admins = _admins.AsQueryable().ToList();
        return Ok(admins);
    }

    [HttpPost]
    public IActionResult Post(Admin admin)
    {
        _admins.InsertOne(admin);
        return Ok();
    }


    [HttpGet("{email}")]
    //Faz a consulta de apenas 1 usuário, com o cpf
    public ActionResult<Admin> GetByEmail(string email)
    {
        var admin = _admins.Find(Admin => Admin.Email == email).FirstOrDefault();
        if (admin == null)
        {
            return NotFound();
        }
        return Ok(admin);
    }

    // HTTP DELETE por CPF
    [HttpDelete("{email}")]
    public IActionResult DeleteByCpf(string email)
    {
        var filter = Builders<Admin>.Filter.Eq(u => u.Email, email);
        var deleteResult = _admins.DeleteOne(filter);

        if (deleteResult.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

}
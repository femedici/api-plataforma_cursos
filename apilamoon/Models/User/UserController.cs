using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
    public ActionResult<User> Post([FromBody] User newUser)
    {
        try
        {
            // Validate the incoming user data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // You may want to add more validation logic for the user data

            // Set the creation date
            newUser.CreationDate = DateTime.Now.ToString();

            // Insert the new user document into MongoDB
            _users.InsertOne(newUser);

            // Return a 201 Created response with the newly created user
            return CreatedAtAction("GetById", new { id = newUser.Id }, newUser);
        }
        catch (Exception ex)
        {
            // Handle any exceptions, log them, and return an error response
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpGet("id/{id}")]

    public async Task<ActionResult<User>> GetById(string id)
    {
        if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        var filterDefinition = Builders<User>.Filter.Eq(user => user.Id, objectId);
        var user = await _users.Find(filterDefinition).SingleOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }


    //Faz a consulta do usuario verificando o email e senha
    [HttpGet("auth")]
    public ActionResult<User> GetLogin([FromQuery] string EmailRequest, [FromQuery] string PasswordRequest)
    {

        //verifica o usuario pelo email
        var userAuth = _users.Find(User => User.Email == EmailRequest).FirstOrDefault();
        if (userAuth == null)
        {
            //caso nao achar o email ja cai
            return NotFound();
        }

        //verifica se as senhas batem
        if (userAuth.Password != PasswordRequest)
        {
            return Unauthorized(); //A senha está incorreta;
        }

        //Passa o usuário autorizado pro login
        return Ok(userAuth);
    }


    //Altera a senha do usuario pelo Id
    [HttpPut("{id}")]
    public async Task<IActionResult> ChangePasswordById(string id, [FromBody] string newPassword)
    {
        if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        var filterDefinition = Builders<User>.Filter.Eq(user => user.Id, objectId);
        var user = await _users.Find(filterDefinition).SingleOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        try
        {
            // Update the user's password
            var updateDefinition = Builders<User>.Update.Set(u => u.Password, newPassword);

            var updateResult = await _users.UpdateOneAsync(filterDefinition, updateDefinition);

            if (updateResult.ModifiedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }
        catch (Exception ex)
        {
            // Handle any exceptions, log them, and return an error response
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    // Deleta por id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(string id)
    {
        if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        var filterDefinition = Builders<User>.Filter.Eq(user => user.Id, objectId);
        var deleteResult = await _users.DeleteOneAsync(filterDefinition);

        if (deleteResult.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

}
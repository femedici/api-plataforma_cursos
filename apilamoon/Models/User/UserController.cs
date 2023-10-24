using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    IMongoCollection<User> _users;
    private List<int> usedIDs = new List<int>(); //lista de ID's do sistema
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

            // Generate a unique 5-digit ID for the new user
            newUser.Id = GenerateUnique5DigitID();

            // Set the creation date
            newUser.CreationDate = DateTime.Now.ToString();

            newUser.Creator = false;

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
    public ActionResult<User> GetById(int id)
    {
        var user = _users.Find(User => User.Id == id).FirstOrDefault();
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
    public async Task<IActionResult> ChangePasswordById(int id, [FromBody] string newPassword)
    {

        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        var user = await _users.Find(filter).SingleOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        try
        {
            // Update the user's password
            var updateDefinition = Builders<User>.Update.Set(u => u.Password, newPassword);

            var updateResult = await _users.UpdateOneAsync(filter, updateDefinition);

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
    // Altera o estado o User/Creator pra True ou False
    [HttpPut("admin-users")]
    public async Task<IActionResult> AlterCreator(int id, [FromBody] bool newCreator)
    {

        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        var user = await _users.Find(filter).SingleOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        try
        {
            var updateDefinition = Builders<User>.Update.Set(u => u.Creator, newCreator);

            var updateResult = await _users.UpdateOneAsync(filter, updateDefinition);

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
    public async Task<IActionResult> DeleteById(int id)
    {

        var deleteResult = await _users.DeleteOneAsync(User => User.Id == id);

        if (deleteResult.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

    // ---------------------------
    // TRATAMENTO DO ID 
    // ---------------------------

    [ApiExplorerSettings(IgnoreApi = true)] // Oculta a ação do Swagger
    [NonAction] // Indica que esta ação não é uma ação da API
    public int GenerateUnique5DigitID()
    {
        Random random = new Random();
        int maxAttempts = 10000; // You can adjust this value based on your needs.

        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            int newID = random.Next(10000, 99999); // Generates a 5-digit random integer.

            // Check if the generated ID is unique (not in use).
            if (!IsIDAlreadyUsed(newID))
            {
                // If it's unique, you can mark it as used in your data source.
                MarkIDAsUsed(newID);
                return newID;
            }
        }

        // If the maximum number of attempts is reached and no unique ID is found, you may handle it accordingly.
        throw new Exception("Unable to generate a unique 5-digit ID.");
    }

    // Check if an ID is already used
    private bool IsIDAlreadyUsed(int id)
    {
        // Implement logic to check if the ID already exists in your data source.
        // For this example, we check against the in-memory list.
        return usedIDs.Contains(id);
    }

    // Mark an ID as used
    private void MarkIDAsUsed(int id)
    {
        // Implement logic to mark the ID as used in your data source.
        // For this example, we add it to the in-memory list.
        usedIDs.Add(id);
    }

}


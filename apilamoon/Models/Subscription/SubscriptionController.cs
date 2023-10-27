using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionController : ControllerBase
{
    IMongoCollection<Subscription> _subscriptions;
    private List<int> usedIDs = new List<int>(); //lista de ID's do sistema
    public SubscriptionController(MeuMongo meuMongo)
    {
        _subscriptions = meuMongo.DB.GetCollection<Subscription>("subscription");
    }

    //Faz a consulta de todas as inscrições existentes
    [HttpGet]
    public IActionResult Get()
    {
        var subscriptions = _subscriptions.AsQueryable().ToList();
        return Ok(subscriptions);
    }

    //Faz a consulta de todas as inscrições do usuario
    [HttpGet("idUser/{idUser}")]
    public ActionResult<Topic> GetByUser(int idUser)
    {
        var subscriptions = _subscriptions.Find(subscription => subscription.IdUser == idUser).ToList();
        if (subscriptions == null)
        {
            return NotFound();
        }
        return Ok(subscriptions);
    }
    [HttpGet("CountUsers")]
    public IActionResult GetCountSubscriptionByID(int idCourse)
    {
        var subscriptions = _subscriptions.Find(subscription => subscription.IdCourse == idCourse).ToList();
        if (subscriptions == null)
        {
            return NotFound();
        }
        return Ok(subscriptions.Count());
    }

    //Faz a consulta de todas as inscrições do curso
    [HttpGet("idCourse/{idCourse}")]
    public ActionResult<Topic> GetByCourse(int idCourse)
    {
        var subscriptions = _subscriptions.Find(subscription => subscription.IdCourse == idCourse).ToList();
        if (subscriptions == null)
        {
            return NotFound();
        }
        return Ok(subscriptions);
    }

    //Cria uma nova inscrição
    [HttpPost]
    public ActionResult<Subscription> Post([FromBody] Subscription newSubscription)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            newSubscription.Id = GenerateUnique5DigitID();

            newSubscription.SubscriptionDate = DateTime.Now.ToString();

            _subscriptions.InsertOne(newSubscription);

            // Use a ação GetByUser para recuperar os detalhes da inscrição recém-criada
            return CreatedAtAction("GetByUser", new { idUser = newSubscription.IdUser }, newSubscription);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    // Deleta uma inscrição pelo ID dela (Quase nunca vai acontecer - nao vis   ivel no front)
    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteById(int id)
    {
        var deleteResult = await _subscriptions.DeleteOneAsync(u => u.Id == id);

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
using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class ProgressionController : ControllerBase
{
    IMongoCollection<Progression> _progressions;
    private List<int> usedIDs = new List<int>(); //lista de ID's do sistema
    public ProgressionController(MeuMongo meuMongo)
    {
        _progressions = meuMongo.DB.GetCollection<Progression>("progression");
    }

    //Faz a consulta de todas as progressões existentes
    [HttpGet]
    public IActionResult Get()
    {
        var progressions = _progressions.AsQueryable().ToList();
        return Ok(progressions);
    }

    //Faz a consulta de todas as progressões de uma inscrição/curso em especifico
    [HttpGet("idSubscription/{idSubscription}")]
    public ActionResult<Topic> GetByUser(int idSubscription)
    {
        var progressions = _progressions.Find(Progression => Progression.IdSubscription == idSubscription).ToList();
        if (progressions == null)
        {
            return NotFound();
        }
        return Ok(progressions);
    }


    //Cria um novo progresso
    [HttpPost]
    public IActionResult Post([FromBody] Progression progression)
    {
         progression.Id = GenerateUnique5DigitID();
         
        _progressions.InsertOne(progression);
        return Ok();
    }

     //Altera o status do progresso
    [HttpPut("{id}/ChangeProgress")]
    public IActionResult ChangeProgressById(int id, [FromBody] bool newProgress)
    {
        var filter = Builders<Progression>.Filter.Eq(u => u.Id, id);
        var progression = _progressions.Find(filter).FirstOrDefault();

        if (progression == null)
        {
            return NotFound();
        }

        var update = Builders<Progression>.Update
            .Set(u => u.Progress, newProgress);

        var updateResult = _progressions.UpdateOne(filter, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
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
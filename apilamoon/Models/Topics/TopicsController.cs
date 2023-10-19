using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController : ControllerBase
{
    IMongoCollection<Topic> _topic;
    private List<int> usedIDs = new List<int>(); //lista de ID's do sistema
    public TopicController(MeuMongo meuMongo)
    {
        _topic = meuMongo.DB.GetCollection<Topic>("topics");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var topics = _topic.AsQueryable().ToList();
        return Ok(topics);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Topic topic)
    {
         topic.Id = GenerateUnique5DigitID();
         
        _topic.InsertOne(topic);
        return Ok();
    }

    [HttpGet("referencecourse/{referencecourse}")]
    public ActionResult<Topic> GetByReferenceCourse(string referencecourse)
    {
        var topics = _topic.Find(topic => topic.ReferenceCourse == referencecourse).ToList();
        if (topics == null)
        {
            return NotFound();
        }
        return Ok(topics);
    }

    [HttpGet("title/{title}")]
    public ActionResult<Topic> GetByTitle(string title)
    {
        var topic = _topic.Find(Topic => Topic.Title == title).FirstOrDefault();
        if (topic == null)
        {
            return NotFound();
        }
        return Ok(topic);
    }

    [HttpPut("{id}")]
    public IActionResult PutByTitle(string id, Topic updatedTopic)
    {
         if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        var filter = Builders<Topic>.Filter.Eq(u => u.Id, objectId);
        var update = Builders<Topic>.Update
            .Set(u => u.Title, updatedTopic.Title)
            .Set(u => u.Description, updatedTopic.Description)
            .Set(u => u.Video, updatedTopic.Video);
        var updateResult = _topic.UpdateOne(filter, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
    }

    //Altera o status do progresso
    [HttpPut("{id}/ChangeProgress")]
    public IActionResult ChangeProgressById(string id, [FromBody] bool newProgress)
    {
         if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        // Verifique se o usuário com o id especificado existe
        var filter = Builders<Topic>.Filter.Eq(u => u.Id, objectId);
        var topic = _topic.Find(filter).FirstOrDefault();

        if (topic == null)
        {
            return NotFound();
        }

        // Atualize a senha do usuário
        var update = Builders<Topic>.Update
            .Set(u => u.Progress, newProgress);

        var updateResult = _topic.UpdateOne(filter, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("{title}")]
    public IActionResult DeleteByTitle(string title)
    {
        var filter = Builders<Topic>.Filter.Eq(u => u.Title, title);
        var deleteResult = _topic.DeleteOne(filter);

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
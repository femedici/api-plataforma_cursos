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
    public ActionResult<Topic> GetByUser(string idUser)
    {
        if(!ObjectId.TryParse(idUser, out ObjectId objectId)){
            return BadRequest("Invalid Object Format");
        }
        var subscriptions = _subscriptions.Find(subscription => subscription.IdUser == objectId).ToList();
        if (subscriptions == null)
        {
            return NotFound();
        }
        return Ok(subscriptions);
    }

    //Faz a consulta de todas as inscrições do curso
    [HttpGet("idCourse/{idCourse}")]
    public ActionResult<Topic> GetByCourse(string idCourse)
    {
        if(!ObjectId.TryParse(idCourse, out ObjectId objectId)){
            return BadRequest("Invalid ObjectId Format");
        }

        var subscriptions = _subscriptions.Find(subscription => subscription.IdCourse == objectId).ToList();
        if (subscriptions == null)
        {
            return NotFound();
        }
        return Ok(subscriptions);
    }

    //Cria uma nova inscrição
    [HttpPost]

    public ActionResult<User> Post([FromBody] Subscription newSubscription)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           // newSubscription.CreationDate = DateTime.Now.ToString();

            _subscriptions.InsertOne(newSubscription);

            return CreatedAtAction("GetById", new { id = newSubscription.Id }, newSubscription);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    // Deleta uma inscrição pelo ID dela (Quase nunca vai acontecer - nao vis   ivel no front)
    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteById(string id)
    {
        if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        var filter = Builders<Subscription>.Filter.Eq(u => u.Id, objectId);
        var deleteResult = await _subscriptions.DeleteOneAsync(filter);

        if (deleteResult.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}
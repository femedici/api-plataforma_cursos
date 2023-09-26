using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<Topic> GetByUser(int idUser)
    {
        var subscriptions = _subscriptions.Find(Subscription => Subscription.IdUser == idUser).ToList();
        if (subscriptions == null)
        {
            return NotFound();
        }
        return Ok(subscriptions);
    }

    //Faz a consulta de todas as inscrições do curso
    [HttpGet("idCourse/{idCourse}")]
    public ActionResult<Topic> GetByCourse(int idCourse)
    {
        var subscriptions = _subscriptions.Find(Subscription => Subscription.IdCourse == idCourse).ToList();
        if (subscriptions == null)
        {
            return NotFound();
        }
        return Ok(subscriptions);
    }

    //Cria uma nova inscrição
    [HttpPost]
    public IActionResult Post(Subscription subscription)
    {
        _subscriptions.InsertOne(subscription);
        return Ok();
    }

    // Deleta uma inscrição pelo ID dela (Quase nunca vai acontecer - nao vis   ivel no front)
    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        var filter = Builders<Subscription>.Filter.Eq(u => u.Id, id);
        var deleteResult = _subscriptions.DeleteOne(filter);

        if (deleteResult.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

}
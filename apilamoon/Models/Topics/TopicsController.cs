using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController : ControllerBase
{
    IMongoCollection<Topic> _topic;
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
    public IActionResult Post(Topic topic)
    {
        _topic.InsertOne(topic);
        return Ok();
    }

    [HttpGet("referencecourse/{referencecourse}")]
    public ActionResult<Topic> GetByReferenceCourse(Course referencecourse)
    {
        var topic = _topic.Find(Topic => Topic.ReferenceCourse == referencecourse).FirstOrDefault();
        if (topic == null)
        {
            return NotFound();
        }
        return Ok(topic);
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

    [HttpPut("{title}")]
    public IActionResult PutByTitle(string title, Topic updatedTopic)
    {
        var filter = Builders<Topic>.Filter.Eq(u => u.Title, title);
        var update = Builders<Topic>.Update
            .Set(u => u.Title, updatedTopic.Title)
            .Set(u => u.Body, updatedTopic.Body)
            .Set(u => u.Attachments, updatedTopic.Attachments)
            .Set(u => u.User_Comments, updatedTopic.User_Comments);
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

}
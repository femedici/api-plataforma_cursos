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
    public ActionResult<Topic> GetByReferenceCourse(int referencecourse)
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

    [HttpPut("video")]
    public async Task<IActionResult> PutVideo(int id, IFormFile videoFile)
    {
        byte[] saveVideo;
        
        using (var memoryStream = new MemoryStream())
        {
            await videoFile.CopyToAsync(memoryStream);
            saveVideo = memoryStream.ToArray();
        }

        var filter = Builders<Topic>.Filter.Eq(u => u.Id, id);
        var update = Builders<Topic>.Update
            .Set(u => u.Video, saveVideo);
        var updateResult = _topic.UpdateOne(filter, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult PutByTitle(int id, Topic updatedTopic)
    {
        var filter = Builders<Topic>.Filter.Eq(u => u.Id, id);
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
    public IActionResult ChangeProgressById(int id, [FromBody] bool newProgress)
    {
        // Verifique se o usuário com o id especificado existe
        var filter = Builders<Topic>.Filter.Eq(u => u.Id, id);
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

}
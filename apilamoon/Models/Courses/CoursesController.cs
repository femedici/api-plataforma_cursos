using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;


namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class CoursesController : ControllerBase
{
    IMongoCollection<Course> _courses;
    public CoursesController(MeuMongo meuMongo)
    {
        _courses = meuMongo.DB.GetCollection<Course>("courses");
    }

    //Faz a consulta de todos os Usuarios cadastrados
    [HttpGet]
    public IActionResult Get()
    {
        var courses = _courses.AsQueryable().ToList();
        return Ok(courses);
    }

    [HttpPost]

    public ActionResult<User> Post(Course newCourse)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _courses.InsertOne(newCourse);
            return CreatedAtAction("GetById", new { id = newCourse.Id }, newCourse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }



    [HttpGet("id/{id}")]
    //Faz a consulta de apenas 1 curso, com o Id
    public async Task<ActionResult<Course>> GetById(string id)
    {
        if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        var filterDefinition = Builders<Course>.Filter.Eq(course => course.Id, objectId);
        var course = await _courses.Find(filterDefinition).SingleOrDefaultAsync();

        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpGet("title/{title}")]
    //Faz a consulta de apenas 1 curso, com o título
    public ActionResult<Course> GetByTitle(string title)
    {
        var course = _courses.Find(Course => Course.Title == title).FirstOrDefault();
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }
    [HttpPut("icon")]
    public IActionResult PutIcon(string id, IFormFile icon)
    {
        if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        MemoryStream memoryStream = new MemoryStream();
        icon.OpenReadStream().CopyTo(memoryStream);

        var filter = Builders<Course>.Filter.Eq(c => c.Id, objectId);
        var update = Builders<Course>.Update
            .Set(c => c.Icon, Convert.ToBase64String(memoryStream.ToArray()));
        var updateResult = _courses.UpdateOne(filter, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPut("{id}")]
    //Faz a consulta de apenas 1 curso, com o Id
    public IActionResult PutById(string id, Course updatedCourse)
    {
        if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        var filter = Builders<Course>.Filter.Eq(c => c.Id, objectId);
        var update = Builders<Course>.Update
            .Set(c => c.Title, updatedCourse.Title)
            .Set(c => c.Icon, updatedCourse.Icon)
            .Set(c => c.MainVideo, updatedCourse.MainVideo)
            .Set(c => c.BodyText, updatedCourse.BodyText)
            .Set(c => c.Attachments, updatedCourse.Attachments)
            .Set(c => c.Description, updatedCourse.Description);
        var updateResult = _courses.UpdateOne(filter, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
    }

    // HTTP DELETE por Id
    [HttpDelete("{id}")]
    public IActionResult DeleteById(string id)
    {
        if (!ObjectId.TryParse(id, out ObjectId objectId))
        {
            return BadRequest("Invalid ObjectId format");
        }

        var filter = Builders<Course>.Filter.Eq(c => c.Id, objectId);
        var deleteResult = _courses.DeleteOne(filter);

        if (deleteResult.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}
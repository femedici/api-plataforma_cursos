using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

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
    public IActionResult Post(Course course)
    {
        _courses.InsertOne(course);
        return Ok();
    }

    [HttpGet("id/{id}")]
    //Faz a consulta de apenas 1 curso, com o Id
    public ActionResult<Course> GetById(int id)
    {
        var course = _courses.Find(Course => Course.Id == id).FirstOrDefault();
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

    [HttpPut("{id}")]
    //Faz a consulta de apenas 1 curso, com o Id
    public IActionResult PutById(int id, Course updatedCourse)
    {

        var filter = Builders<Course>.Filter.Eq(c => c.Id, id);
        var update = Builders<Course>.Update
            .Set(c => c.Title, updatedCourse.Title)
            .Set(c => c.ImageCourse, updatedCourse.ImageCourse)
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
    public IActionResult DeleteById(int id)
    {
        var filter = Builders<Course>.Filter.Eq(c => c.Id, id);
        var deleteResult = _courses.DeleteOne(filter);

        if (deleteResult.DeletedCount == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}
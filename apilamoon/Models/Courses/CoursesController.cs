using MainProfiles.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace MainProfiles.Controllers;

[ApiController]
[Route("[controller]")]
public class CoursesController : ControllerBase
{
    IMongoCollection<Course> _courses;

    private List<int> usedIDs = new List<int>(); //lista de ID's do sistema
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
    public ActionResult<Course> Post(Course newCourse)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Generate a unique 5-digit ID for the new user
            newCourse.Id = GenerateUnique5DigitID();

            // Set the creation date
            newCourse.CreationDate = DateTime.Now.ToString();

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
    public async Task<ActionResult<Course>> GetById(int id)
    {

        var course = await _courses.Find(Course => Course.Id == id).SingleOrDefaultAsync();

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
    public IActionResult PutIcon(int id, IFormFile icon)
    {
        MemoryStream memoryStream = new MemoryStream();
        icon.OpenReadStream().CopyTo(memoryStream);

        var update = Builders<Course>.Update
            .Set(c => c.Icon, Convert.ToBase64String(memoryStream.ToArray()));
        var updateResult = _courses.UpdateOne(c => c.Id == id, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPut("{id}")]
    //Faz a consulta de apenas 1 curso, com o Id
    public IActionResult PutById(int id, Course updatedCourse)
    {

        var filter = Builders<Course>.Filter.Eq(c => c.Id, id);
        var update = Builders<Course>.Update
            .Set(c => c.Title, updatedCourse.Title)
            .Set(c => c.Icon, updatedCourse.Icon)
            .Set(c => c.MainVideo, updatedCourse.MainVideo)
            .Set(c => c.BodyText, updatedCourse.BodyText)
            .Set(c => c.Description, updatedCourse.Description);
        var updateResult = _courses.UpdateOne(filter, update);

        if (updateResult.ModifiedCount == 0)
        {
            return NotFound();
        }

        return Ok();
    }

    // Deleta por id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {

        var deleteResult = await _courses.DeleteOneAsync(Course => Course.Id == id);

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
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class User
{
    [Required]
    [BsonElement("id")]
    public int Id { get; set; } 

    [BsonElement("name")]
    [Required]
    public string? Name { get; set; }

    [BsonElement("email")]
    [Required]
    public string? Email { get; set; }

    [BsonElement("password")]
    [Required]
    public string? Password { get; set; }

    [BsonElement("icon")]
    public string? Icon { get; set; }

    [BsonElement("creationDate")]
    public string? CreationDate {get; set;}

}
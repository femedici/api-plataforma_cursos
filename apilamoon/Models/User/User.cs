using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class User
{
    [Required]
    [BsonElement("cpf")]
    public string? Cpf { get; set; }

    [BsonElement("name")]
    [Required]
    public string? Name { get; set; }

    [BsonElement("email")]
    [Required]
    public string? Email { get; set; }
    
    [BsonElement("password")]
    [Required]
    public string? Password { get; set; }
}
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class Admin
{
    [BsonElement("email")]
    [Required]
    public string? Email {get; set;}

    [BsonElement("password")]
    [Required]
    public string? Password {get; set;}
}
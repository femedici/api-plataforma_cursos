using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class Course
{
    [Required]
    [BsonElement("id")]
    public int Id { get; set; }

    [Required]
    [BsonElement("title")]
    public string? Title { get; set; }

    [BsonElement("icon")]
    [Required]
    public string? Icon { get; set; }

    [BsonElement("cover")]
    [Required]
    public string? Cover { get; set; }

    [BsonElement("body")]
    [Required]
    public string? body { get; set; }

    [BsonElement("attachments")]
    [Required]
    public string? Attachments { get; set; }

    [BsonElement("password")]
    [Required]
    public string? Password { get; set; }

    [BsonElement("topic")]
    [Required]
    public Topic? Topic { get; set; }

    [BsonElement("comments")]
    [Required]
    public string? Comments { get; set; }

    [BsonElement("joined_users")]
    [Required]
    public User? joined_users { get; set; }

    [BsonElement("former")]
    [Required]
    public User? Former { get; set; }

    [BsonElement("general_progression")]
    [Required]
    public int? General_Progression { get; set; }

    [BsonElement("user_progression")]
    [Required]
    public int? User_Progression { get; set; }
}
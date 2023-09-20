using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class Topic
{
    [Required]
    [BsonElement("id")]
    public int Id { get; set; }
    
    [Required]
    [BsonElement("referencecourse")]
    public int? ReferenceCourse { get; set; }

    [BsonElement("title")]
    [Required]
    public string? Title { get; set; }

    // [BsonElement("capa")]
    // [Required]
    // public string? Capa { get; set; }

    [BsonElement("body")]
    [Required]
    public string? Body { get; set; } 
    
    [BsonElement("attachments")]
    [Required]
    public string? Attachments { get; set;} 
    
    [BsonElement("user_comments")]
    [Required]
    public string? User_Comments { get; set; }

    // [BsonElement("progressao")]
    // [Required]
    // public string? Progressao { get; set; }
}
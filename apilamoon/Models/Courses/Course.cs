using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class Course
{
    
    [BsonId, BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("title")]
    [Required]
    public string? Title { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("mainVideo")]
    public string? MainVideo { get; set; }

    [BsonElement("bodyText")]
    public string? BodyText { get; set; }

    [BsonElement("attachments")]
    public string? Attachments { get; set; }

    [BsonElement("password")]
    public string? Password { get; set; }

    [BsonElement("icon")]
    public string? Icon { get; set; }

    [BsonElement("topicsCount")]
    public int? TopicsCount { get; set; }

    [BsonElement("creator")]
    public string? Creator { get; set; }
    public Course()
    {
        Id = ObjectId.GenerateNewId();
    }
}
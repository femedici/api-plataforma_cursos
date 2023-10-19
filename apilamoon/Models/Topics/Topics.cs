using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class Topic
{
    [BsonId, BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; } 

    [Required]
    [BsonElement("referencecourse")]
    public string? ReferenceCourse { get; set; }

    [BsonElement("title")]
    [Required]
    public string? Title { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("video")]
    public string? Video { get; set; }

    [BsonElement("progress")]
    public bool? Progress { get; set; }

    public Topic()
    {
        Id = ObjectId.GenerateNewId();
    }
}
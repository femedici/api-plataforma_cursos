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
    public int ReferenceCourse { get; set; }

    [BsonElement("title")]
    [Required]
    public string? Title { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("video")]
    public byte[]? Video { get; set; }

    [BsonElement("progress")]
    public bool? Progress { get; set; }
}
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class Course
{

    [BsonElement("id")]
    public int Id { get; set; }

    [BsonElement("title")]
    [Required]
    public string? Title { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("mainVideo")]
    public string? MainVideo { get; set; }

    [BsonElement("bodyText")]
    public string? BodyText { get; set; }

    [BsonElement("password")]
    public string? Password { get; set; }

    [BsonElement("icon")]
    public string? Icon { get; set; }

    [BsonElement("banner")]
    public string? Banner { get; set; }

    [BsonElement("creator")]
    public string? Creator { get; set; }

    [BsonElement("creatorID")]
    public int CreatorID { get; set; }

    [BsonElement("creationDate")]
    public string? CreationDate { get; set; }
}

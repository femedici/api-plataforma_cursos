using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class Subscription
{
    [Required]
    [BsonElement("id")]
    public int Id{ get; set; }

    [Required]
    [BsonElement("idCourse")]
    public int IdCourse { get; set; }

    [BsonElement("idUser")]
    [Required]
    public int IdUser { get; set; }

    [BsonElement("progression")]
    public int? Progression { get; set; }

    [BsonElement("subscriptionDate")]
    public string? SubscriptionDate { get; set; }

    [BsonElement("conclusionDate")]
    public string? ConclusionDate { get; set; }
}
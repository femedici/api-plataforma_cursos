using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class Subscription
{
    [BsonId, BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; } 

    [BsonId, BsonElement("idCourse"), BsonRepresentation(BsonType.ObjectId)]
    public ObjectId IdCourse { get; set; } 
    
    [BsonId, BsonElement("idUser"), BsonRepresentation(BsonType.ObjectId)]
    public ObjectId IdUser { get; set; } 

    [BsonElement("progression")]
    public int? Progression { get; set; }

    [BsonElement("subscriptionDate")]
    public string? SubscriptionDate { get; set; }

    [BsonElement("conclusionDate")]
    public string? ConclusionDate { get; set; }
}
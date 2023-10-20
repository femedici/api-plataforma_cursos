using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class Subscription
{
    [BsonElement("id")]
    public int Id { get; set; } 

    [BsonElement("idCourse")]
    public int IdCourse { get; set; } 
    
    [BsonElement("idUser")]
    public int IdUser { get; set; } 

    [BsonElement("progression")]
    public int? Progression { get; set; }

    [BsonElement("subscriptionDate")]
    public string? SubscriptionDate { get; set; }

    [BsonElement("conclusionDate")]
    public string? ConclusionDate { get; set; }
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MainProfiles.Models;
[BsonIgnoreExtraElements]
public class Progression
{
    [BsonElement("id")]
    public int Id { get; set; } 

    [BsonElement("idSubscription")]
    public int IdSubscription { get; set; } 
    
    [BsonElement("idTopic")]
    public int IdTopic { get; set; } 

    [BsonElement("progress")]
    public bool? Progress { get; set; }
}

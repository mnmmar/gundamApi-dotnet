using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GundamApi.Models;

public class Gundam
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string GundamName { get; set; } = null!;

    public decimal Price { get; set; }

    public int ShippingCost { get; set; }

    public string ShippingDate { get; set; } = null!;

    public string ImageLink { get; set; } = null!;
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class Chiste
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public bool Enabled { get; set; }
    public int Likes { get; set; }
    public int Unlikes { get; set; }
}

public class NewChisteDTO
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
}
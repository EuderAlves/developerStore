using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonRequired]
    public string Email { get; set; }

    [BsonRequired]
    public string PasswordHash { get; set; }

    public string Name { get; set; }

    public User()
    {
        Email = string.Empty;
        PasswordHash = string.Empty;
        Name = string.Empty;
    }
}
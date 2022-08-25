using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestGenerationAPI.Entity
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId = null!;
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestGenerationAPI.Entity
{
    public enum RoleTypes
    {
        JUNIOR_LEVEL,
        MID_LEVEL,
        SENIOR_LEVEL
    };

    public enum DifficultyLevels
    {
        EASY,
        MEDIUM,
        HARD
    };


    public class TestPaperModel
    {
        [BsonElement("id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestPaperId = null!;

        public string PaperId => TestPaperId;
        public List<string> Skills { get; init; } = new List<string>();

        public RoleTypes RoleType { get; set; }

        public string TestName { get; set; } = null!;

        public string Author { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime DateCreated;

        public DateTime LastModified;

        public DateTime DeactivatedOn;

        public string CopyOfTestPaper { get; set; } = null!;
    }

}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestGenerationAPI.Entity
{
    public enum RoleTypes
    {
        JUNIOR_LEVEL=0,
        MID_LEVEL,
        SENIOR_LEVEL
    };

    public enum DifficultyLevels
    {
        EASY=0,
        MEDIUM,
        HARD
    };

    public enum Active
    {
        NO=0,
        YES=1
    }

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

        public Active IsActive { get; set; }

        public DateTime DateCreated;

        public DateTime LastModified;

        public DateTime DeactivatedOn;

        public string CopyOfTestPaper { get; set; } = null!;
    }

}

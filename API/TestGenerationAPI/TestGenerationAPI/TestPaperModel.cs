using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestGenerationAPI
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
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestPaperId { get; set; }

        public List<string> Skills { get; init; } = new List<string>();

        public RoleTypes RoleType { get; set; }

        public string TestName { get; set; }

        public string Author { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime DeactivatedOn { get; set; }

        public string CopyOfTestPaper { get; set; }
    }

}

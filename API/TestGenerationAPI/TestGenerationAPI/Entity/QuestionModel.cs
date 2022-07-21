using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TestGenerationAPI.Entity
{
    public class QuestionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionId;

        public string QuestionName { get; set; } = null!;

        public List<string> skill { get; init; } = new List<string>();

        public DifficultyLevels DifficultyLevel { get; set; }

        public RoleTypes RoleType { get; set; }

        public string ProblemStatement { get; set; } = null!;


        private string[] options;

        public string[] Options { get => options; set => options = value; }

        public bool IsActive { get; set; }

        public DateTime LastModified;

        public DateTime DateCreated;

        public DateTime DeactivatedOn { get; set; }

        public string CopyOff { get; set; } = null!;

    }
}

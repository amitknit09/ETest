using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestGenerationAPI
{
    public class QuestionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionId { get; set; }

        public string QuestionName { get; set; }

        public List<string> skill { get; init; } = new List<string>();

        public DifficultyLevels DifficultyLevel { get; set; }

        public RoleTypes RoleType { get; set; }

        public string ProblemStatement;


        private string[] options;

        public string[] Options { get => options; set => options = value; }

        public bool IsActive { get; set; }

        public DateTime lastUpdated { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DeactivatedOn { get; set; }

        public string CopyOff { get; set; }
    }
}

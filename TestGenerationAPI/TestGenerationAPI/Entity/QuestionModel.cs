using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TestGenerationAPI.Entity
{
    public class PostQuestionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionId = null!;

        public string Skill { get; set; } 

        public DifficultyLevels DifficultyLevel { get; set; }

        public RoleTypes RoleType { get; set; }

        public string ProblemStatement { get; set; } = null!;


        private string[] options;

        public string[] Options { get => options; set => options = value; }

        public Active IsActive { get; set; }

        public string Author { get; set; } = null!;

        public DateTime LastModified;

        public DateTime DateCreated;

        public DateTime DeactivatedOn;

        public string Answer { get; set; } = null!;

    }

    public class GetQuestionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionId = null!;

        public string QuesId => QuestionId;
        public string Skill { get; set; }

        public DifficultyLevels DifficultyLevel { get; set; }

        public RoleTypes RoleType { get; set; }

        public string ProblemStatement { get; set; } = null!;


        private string[] options;

        public string[] Options { get => options; set => options = value; }

        public Active IsActive { get; set; }

        public string Author { get; set; } = null!;

        public DateTime LastModified;

        public DateTime DateCreated;

        public DateTime DeactivatedOn;

        public string Answer { get; set; } = null!;

    }
}

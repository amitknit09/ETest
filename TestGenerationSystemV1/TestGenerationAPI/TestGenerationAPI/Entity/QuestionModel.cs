using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TestGenerationAPI.Entity
{
    public class QuestionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionId = null!;

        //public string QuestId => QuestionId;

        public string QuestionName { get; set; } = null!;

        public string Skill { get; set; } 

        public DifficultyLevels DifficultyLevel { get; set; }

        public RoleTypes RoleType { get; set; }

        public string ProblemStatement { get; set; } = null!;


        private string[] options;

        public string[] Options { get => options; set => options = value; }

        public bool IsActive { get; set; }

        public string Author { get; set; } = null!;

        public DateTime LastModified;

        public DateTime DateCreated;

        public DateTime DeactivatedOn;

        public string CopyOff { get; set; } = null!;

    }
}

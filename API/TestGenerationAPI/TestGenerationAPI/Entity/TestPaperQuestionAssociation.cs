namespace TestGenerationAPI.Entity
{
    public class TestPaperQuestionAssociation
    {
        public string TestPaperId { get; set; }
        public List<string> QuestionIds { get; set; } = new List<string>();
    }
}

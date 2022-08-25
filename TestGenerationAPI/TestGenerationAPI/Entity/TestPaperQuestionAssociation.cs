namespace TestGenerationAPI.Entity
{
    public class TestPaperQuestionAssociation
    {
        public string TestPaperId { get; set; } = null!;
        public List<string> QuestionIds { get; set; } = new List<string>();
    }
}

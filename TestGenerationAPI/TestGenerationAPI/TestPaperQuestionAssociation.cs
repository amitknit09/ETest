namespace TestGenerationAPI
{
    public class TestPaperQuestionAssociation
    {
        public int TestPaperId { get; set; }
        public List<string> QuestionIds { get; set; } = new List<string>();
    }
}

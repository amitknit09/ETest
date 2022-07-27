namespace TestGenerationAPI
{
    public class TestGenerationSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string QuestionsBankCollection { get; set; } = null!;
        public string TestPaperCollection { get; set; } = null!;
        public string AssociationCollection { get; set; } = null!;
    }
}

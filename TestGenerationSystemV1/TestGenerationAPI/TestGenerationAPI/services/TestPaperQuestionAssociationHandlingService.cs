using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestGenerationAPI.Entity;

namespace TestGenerationAPI.services
{
    public class TestPaperQuestionAssociationHandlingService
    {
        private IOptions<TestGenerationSettings> _settings;

        private IMongoDatabase _db;

        private string _collectionName;
        public TestPaperQuestionAssociationHandlingService(IOptions<TestGenerationSettings> settings)
        {
            _settings = settings;
            var client = new MongoClient();
            _db = client.GetDatabase(settings.Value.DatabaseName);
            _collectionName = settings.Value.AssociationCollection;
        }

        public void AddEntry(TestPaperQuestionAssociation model)
        {
            _db.GetCollection<TestPaperQuestionAssociation>(_collectionName).InsertOne(model);
        }

        public void UpdateEntry(string id, TestPaperQuestionAssociation model)
        {
            _db.GetCollection<TestPaperQuestionAssociation>(_collectionName).ReplaceOne(id, model);
        }
    }
}

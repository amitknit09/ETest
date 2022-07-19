using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TestGenerationAPI
{
    public class TestPaperHandlingService
    {
        private IOptions<TestGenerationSettings> _settings;

        private IMongoDatabase _db;

        private string _collectionName;
        public TestPaperHandlingService(IOptions<TestGenerationSettings> settings)
        {
            _settings = settings;
            var client = new MongoClient();
            _db = client.GetDatabase(settings.Value.DatabaseName);
            _collectionName = settings.Value.TestPaperCollection;
        }


        public void SaveTestPaper(TestPaperModel model)
        {
            _db.GetCollection<TestPaperModel>(_collectionName).InsertOne(model);
        }


        public void UpdateTestPaper(TestPaperModel model)
        {
            _db.GetCollection<TestPaperModel>(_collectionName).ReplaceOne(model.TestPaperId, model);
        }
    }
}

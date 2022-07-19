using Microsoft.Extensions.Options;
using TestGenerationAPI;
using MongoDB.Driver;

namespace TestGenerationAPI
{
    public class QuestionHandlingService
    {

        private IOptions<TestGenerationSettings> _settings;

        private IMongoDatabase _db;

        private string _collectionName;
        public QuestionHandlingService(IOptions<TestGenerationSettings> settings)
        {
            _settings = settings;
            var client = new MongoClient();
            _db = client.GetDatabase(settings.Value.DatabaseName);
            _collectionName = _settings.Value.QuestionsBankCollection;
        }

        public QuestionModel RetrieveQuestion(string id)
        {
            return _db.GetCollection<QuestionModel>(_collectionName).Find(id).First();
        }
        public void InsertQuestion(QuestionModel question)
        {
            _db.GetCollection<QuestionModel>(_collectionName).InsertOne(question);
        }

        public void UpdateQuestion(string id, QuestionModel question)
        {
            _db.GetCollection<QuestionModel>(_collectionName).ReplaceOne(id, question);
        }

        public void DeleteQuestion(string id)
        {
            _db.GetCollection<QuestionModel>(_collectionName).DeleteOne(id);
        }
    }
}

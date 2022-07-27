using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TestGenerationAPI.Entity;

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

        public List<QuestionModel> RetrieveAllQuestions()
        {
            return _db.GetCollection<QuestionModel>(_collectionName).FindSync(x => x.IsActive == true).ToList();
        }

        public QuestionModel RetrieveQuestion(string id)
        {
            var client = new MongoClient();
            return _db.GetCollection<QuestionModel>(_collectionName)
                .Find(x => x.QuestionId == id)
                .First();
        }
        public void InsertQuestion(QuestionModel question)
        {
            _db.GetCollection<QuestionModel>(_collectionName)
                .InsertOne(question);
        }

        public void UpdateQuestion(string id, QuestionModel question)
        {
            _db.GetCollection<QuestionModel>(_collectionName)
                .ReplaceOne(x => x.QuestionId == id, question);
        }

        public void DeleteQuestion(string id)
        {
            _db.GetCollection<QuestionModel>(_collectionName)
                .DeleteOne(id);
        }
    }
}

using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TestGenerationAPI.Entity;

namespace TestGenerationAPI.services
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

        public List<GetQuestionModel> RetrieveAllQuestions()
        {
            var questions = _db.GetCollection<GetQuestionModel>(_collectionName)
                .FindSync(x => x.IsActive == Active.YES)
                .ToList();
            return questions;
        }

        public GetQuestionModel RetrieveQuestion(string id)
        {
            var client = new MongoClient();
            return _db.GetCollection<GetQuestionModel>(_collectionName)
                .Find(x => x.QuestionId == id)
                .First();
        }
        public void InsertQuestion(PostQuestionModel question)
        {
            _db.GetCollection<PostQuestionModel>(_collectionName)
                .InsertOne(question);
        }

        public void UpdateQuestion(string id, PostQuestionModel question)
        {
            _db.GetCollection<PostQuestionModel>(_collectionName)
                .ReplaceOne(x => x.QuestionId == id, question);
        }

        public void DeleteQuestion(string id)
        {
            _db.GetCollection<PostQuestionModel>(_collectionName)
                .DeleteOne(id);
        }
    }
}

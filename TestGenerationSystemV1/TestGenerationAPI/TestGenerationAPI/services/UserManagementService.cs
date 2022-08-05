using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestGenerationAPI.Entity;

namespace TestGenerationAPI.services
{
    public class UserManagementService
    {
        private IOptions<TestGenerationSettings> _settings;

        private IMongoDatabase _db;

        private string _collectionName;

        public UserManagementService(IOptions<TestGenerationSettings> settings)
        {
            _settings = settings;
            _db = new MongoClient().GetDatabase(settings.Value.DatabaseName);
            _collectionName = settings.Value.UserCollection;
        }

        public string CreateUser(UserModel user)
        {
            var Users = _db.GetCollection<UserModel>(_collectionName).Find(x => x.Name == user.Name);
            if (Users == null || Users?.CountDocuments() == 0)
            {
                _db.GetCollection<UserModel>(_collectionName).InsertOne(user);
                return "User created";
            }
            else
                return "User already exist with same user name";

        }

        public UserModel UserLogin(string name, string password)
        {
            var Users = _db.GetCollection<UserModel>(_collectionName).Find(x => x.Name == name && x.Password == password);
            if (Users == null || Users?.CountDocuments() == 0)
                return null;
            else
                return Users.First();
        }
    }
}

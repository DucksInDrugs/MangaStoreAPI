using MangaStoreAPI.Entities.Interface;
using MangaStoreAPI.Repository.Interfaces;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace MangaStoreAPI.Repository
{
    public class ProjectRepository<T> : IProjectRepository<T> where T : IDocument
    {
        private readonly IMongoCollection<T> _collection;

        public ProjectRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public Task<List<T>> GetAllAsync()
        {
            return Task.Run(() => _collection.Find(doc => true).ToListAsync());
        }

        public Task<T> GetByIdAsync(string id)
        {
            return Task.Run(() => _collection.Find(doc => doc._id == id).SingleOrDefaultAsync());
        }

        public Task InsertOneAsync(T document)
        {
            return Task.Run(() =>
            {
                document._id = new BsonObjectIdGenerator().GenerateId(_collection, document).ToString();
                _collection.InsertOneAsync(document);
            });
        }

        public void ReplaceOneAsync(string id, T document)
        {
            Task.Run(() => _collection.ReplaceOneAsync(doc => doc._id == id, document));
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() => _collection.FindOneAndDeleteAsync(doc => doc._id == id));
        }
    }
}

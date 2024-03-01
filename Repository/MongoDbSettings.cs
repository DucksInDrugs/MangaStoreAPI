using MangaStoreAPI.Repository.Interfaces;

namespace MangaStoreAPI.Repository
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MangaStoreAPI.Entities.Interface
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string _id { get; set; }
    }
}

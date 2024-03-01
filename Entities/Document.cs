using MangaStoreAPI.Entities.Interface;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MangaStoreAPI.Entities
{
    public class Document : IDocument
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}

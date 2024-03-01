using MangaStoreAPI.Entities;
using MangaStoreAPI.Repository;

namespace MangaStoreAPI.Models
{
    [BsonCollection("Authors")]
    public class Authors : Document
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}

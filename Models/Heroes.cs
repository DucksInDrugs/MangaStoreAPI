using MangaStoreAPI.Entities;
using MangaStoreAPI.Repository;

namespace MangaStoreAPI.Models
{
    [BsonCollection("Heroes")]
    public class Heroes : Document
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

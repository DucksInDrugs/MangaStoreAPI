using MangaStoreAPI.Entities;
using MangaStoreAPI.Repository;

namespace MangaStoreAPI.Models
{
    [BsonCollection("Heroes")]
    public class Heroes : Document
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string? PhotoURL { get; set; }
        public string Description { get; set; }
    }
}

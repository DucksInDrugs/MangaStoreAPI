using MangaStoreAPI.Entities;
using MangaStoreAPI.Repository;

namespace MangaStoreAPI.Models
{
    [BsonCollection("Genres")]
    public class Genres : Document
    {
        public string Name { get; set; }
        public string PhotoURL { get; set; }
    }
}

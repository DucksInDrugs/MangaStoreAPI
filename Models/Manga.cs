using MangaStoreAPI.Entities;
using MangaStoreAPI.Repository;

namespace MangaStoreAPI.Models
{
    [BsonCollection("Manga")]
    public class Manga : Document
    {
        public string TitleName { get; set; }
        public DateTime StartDate { get; set; }
    }
}

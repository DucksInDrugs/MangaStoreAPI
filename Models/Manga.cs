using MangaStoreAPI.Entities;
using MangaStoreAPI.Repository;

namespace MangaStoreAPI.Models
{
    [BsonCollection("Manga")]
    public class Manga : Document
    {
        public string TitleName { get; set; }
        public double? Rating { get; set; }
        public string PhotoURL { get; set; }
        public List<string> MangaURLs { get; set; }
    }
}

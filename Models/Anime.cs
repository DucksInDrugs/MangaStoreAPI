using MangaStoreAPI.Entities;
using MangaStoreAPI.Repository;

namespace MangaStoreAPI.Models
{
    [BsonCollection("Anime")]
    public class Anime : Document
    {
        public string TitleName { get; set; }
        public double? Rating { get; set; }
        public int Episodes { get; set; }
        public Manga MangaName { get; set; }
    }
}

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
        public string? PhotoPath { get; set; }
        public string? TrailerURL { get; set; }
        public string? GenreID { get; set; }
        public string? AuthorID { get; set; }
        public List<string>? HeroesIDs { get; set; }
    }
}

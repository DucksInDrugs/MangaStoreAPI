using MangaStoreAPI.Entities;
using MangaStoreAPI.Repository;

namespace MangaStoreAPI.Models
{
    [BsonCollection("Authors")]
    public class Authors : Document
    {
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        public string Category { get; set; }
        public List<string> ProductsID { get; set; }
    }
}

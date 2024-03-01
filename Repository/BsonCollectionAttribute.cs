namespace MangaStoreAPI.Repository
{
    public class BsonCollectionAttribute : Attribute
    {
        public string CollectionName { get; set; }

        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}

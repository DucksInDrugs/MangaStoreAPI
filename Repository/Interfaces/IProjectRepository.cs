using MangaStoreAPI.Entities.Interface;

namespace MangaStoreAPI.Repository.Interfaces
{
    public interface IProjectRepository<T> where T : IDocument
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task InsertOneAsync(T document);
        void ReplaceOneAsync(string id, T document);
        Task DeleteByIdAsync(string id);
    }
}

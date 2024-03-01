using MangaStoreAPI.Entities.Interface;

namespace MangaStoreAPI.Services.Interfaces
{
    public interface IProjectService<T> where T : IDocument
    {
        List<T> GetAll();
        T GetById(string id);
        void Insert(T product);
        void Update(string id, T productToChange);
        void Delete(string id);
    }
}

using MangaStoreAPI.Entities.Interface;
using MangaStoreAPI.Repository.Interfaces;
using MangaStoreAPI.Services.Interfaces;

namespace MangaStoreAPI.Services
{
    public class ProjectService<T> : IProjectService<T> where T : IDocument
    {
        private readonly IProjectRepository<T> _productsRepository;

        public ProjectService(IProjectRepository<T> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public void Delete(string id)
        {
            _productsRepository.DeleteByIdAsync(id);
        }

        public List<T> GetAll()
        {
            Task<List<T>> products = _productsRepository.GetAllAsync();

            return products.Result;
        }

        public T GetById(string id)
        {
            Task<T> products = _productsRepository.GetByIdAsync(id);

            return products.Result;
        }

        public void Insert(T product)
        {
            _productsRepository.InsertOneAsync(product);
        }

        public void Update(string id, T productToChange)
        {
            _productsRepository.ReplaceOneAsync(id, productToChange);
        }
    }
}

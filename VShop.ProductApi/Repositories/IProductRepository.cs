using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetProductsCategories();
        Task<Product> GetById(int id);
        Task<Product> Create(Product category);
        Task<Product> Update(Product category);
        Task<Product> Delete(int id);
    }
}

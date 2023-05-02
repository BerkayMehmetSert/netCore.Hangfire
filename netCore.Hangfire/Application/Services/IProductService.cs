using netCore.Hangfire.Application.Requests;
using netCore.Hangfire.Models.Entities;

namespace netCore.Hangfire.Application.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<Product> CreateProduct(CreateProductRequest request);
        Task<Product> UpdateProduct(Guid id, UpdateProductRequest request);
        Task<Product> DeleteProduct(Guid id);
    }
}

using Hangfire;
using netCore.Hangfire.Application.Jobs;
using netCore.Hangfire.Application.Repositories;
using netCore.Hangfire.Application.Requests;
using netCore.Hangfire.Models.Entities;

namespace netCore.Hangfire.Application.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmailBackgroundJob _emailBackgroundJob;

        public ProductManager(IProductRepository productRepository, IUnitOfWork unitOfWork, EmailBackgroundJob emailBackgroundJob)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _emailBackgroundJob = emailBackgroundJob;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return products;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _productRepository.Get(x => x.Id == id);
            return product;
        }

        public async Task<Product> CreateProduct(CreateProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            _productRepository.Create(product);
            await _unitOfWork.SaveChangesAsync();

            BackgroundJob.Enqueue(() => _emailBackgroundJob.SendEmailWithProduct(request.Name, request.Price));

            return product;
        }

        public async Task<Product> UpdateProduct(Guid id, UpdateProductRequest request)
        {
            var product = await _productRepository.Get(x => x.Id == id);

            product.Name = request.Name;
            product.Description = request.Description;

            if (request.Price > product.Price || request.Price < product.Price)
            {
                BackgroundJob.Enqueue(() => _emailBackgroundJob.SendEmailWithProduct(request.Name, request.Price));
            }

            product.Price = request.Price;

            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteProduct(Guid id)
        {
            var product = await _productRepository.Get(x => x.Id == id);

            _productRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync();

            return product;
        }
    }
}

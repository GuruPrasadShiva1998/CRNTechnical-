using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data.Repositories;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _uow.Products.GetAllAsync();

        public async Task<Product> CreateAsync(ProductDto dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                CreatedBy = "Admin",
                CreatedOn = DateTime.UtcNow
            };

            await _uow.Products.AddAsync(product);
            await _uow.SaveAsync();

            return product;
        }
    }
}

using AutoMapper;
using Base64rontTest.Data;
using Base64rontTest.DTOs;
using Base64rontTest.Models;
using Microsoft.EntityFrameworkCore;

namespace Base64rontTest.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int productId)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            _appDbContext.Products.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            _appDbContext.Products.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                return false;
            }

            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<int>> ActivateOrDeactivateProductsAsync(List<int> productIds, bool isActive)
        {
            foreach (var productId in productIds)
            {
                var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product != null)
                {
                    product.IsActive = isActive;
                }
            }
            await _appDbContext.SaveChangesAsync();
            return productIds;
        }
    }
}

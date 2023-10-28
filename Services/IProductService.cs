using Base64rontTest.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base64rontTest.Services
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProductAsync(ProductDTO product);
        Task<ProductDTO> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> UpdateProductAsync(ProductDTO product);
        Task<bool> DeleteProductAsync(int productId);
        Task<IEnumerable<int>> ActivateOrDeactivateProductsAsync(List<int> productIds, bool isActive);
    }
}

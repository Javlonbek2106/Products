using AutoMapper;
using Base64rontTest.DTOs;
using Base64rontTest.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
    {
        try
        {
            var productId = await _productService.CreateProductAsync(productDTO);
            return Ok(productId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDTO)
    {
        try
        {
            var success = await _productService.UpdateProductAsync(productDTO);
            return NotFound("Product not found.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            var success = await _productService.DeleteProductAsync(id);
            if (success)
            {
                return NoContent();
            }
            return NotFound("Product not found.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> ActivateOrDeactivateProductsAsync([FromBody] List<int> productIds, bool isActive)
    {
        try
        {
            var updatedProductIds = await _productService.ActivateOrDeactivateProductsAsync(productIds, isActive);
            if (updatedProductIds != null && updatedProductIds.Any())
            {
                return Ok(updatedProductIds);
            }
            return NotFound("No products found for the given IDs.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

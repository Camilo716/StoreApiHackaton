using HackatonApi.Data.Repositories;
using HackatonApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackatonApi.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> PostProductAsync(Product product)
    {
        product.EntryDate = DateTime.Now;
        product.state = "Almacenado";
        return await _productRepository.SaveAsync(product);
    }

    public async Task<ActionResult<Product>> GetProductByUIPAsync(string iup)
    {
        var product = await _productRepository.GetByUIPAsync(iup);

        if (product == null)
            throw new KeyNotFoundException($"Actor with id {iup} not found");

        return product;

    }
}
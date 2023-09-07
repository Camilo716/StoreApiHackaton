using HackatonApi.Data.Repositories;
using HackatonApi.DTOs;
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

    // internal async Task<Product> UnstoreProduct(string iup, Product product)
    // {
    //     product.DeliveryDate = DateTime.Now;
    //     product.state = "No almacenado";
    //     return await _productRepository.UpdateAsync(iup, product);
    // }

    // internal async Task<List<Product>> GetProductsByZoneAsync(string zoneKey)
    // {
    //     List<Product> products = await _productRepository.GetByZoneAsync(zoneKey);

    //     if (products == null)
    //         throw new KeyNotFoundException($"Actor with id {zoneKey} not found");

    //     return products;
    // }
}
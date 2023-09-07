using HackatonApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackatonApi.Data.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<ActionResult<Product>> GetByUIPAsync(string uip);
    Task<Product> SaveAsync(Product product);
}
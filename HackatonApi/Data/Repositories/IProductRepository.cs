using HackatonApi.Models;

namespace HackatonApi.Data.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
}
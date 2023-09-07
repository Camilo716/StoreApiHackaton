using HackatonApi.Data.Repositories;
using HackatonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Data.EntityFramework;

public class EfProductRepository : IProductRepository
{

    private readonly ApplicationDbContext _context;

    public EfProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
}
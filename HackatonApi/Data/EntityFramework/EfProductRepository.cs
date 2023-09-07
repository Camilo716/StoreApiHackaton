using HackatonApi.Data.Repositories;
using HackatonApi.Models;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<ActionResult<Product>> GetByUIPAsync(string iup)
    {
        return await _context.Products
             .FirstOrDefaultAsync(a => a.IUP_code == iup);
    }

    public async Task<Product> SaveAsync(Product product)
    {
        var productEntry = await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        return productEntry.Entity;
    }
}
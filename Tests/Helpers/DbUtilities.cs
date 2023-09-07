using HackatonApi.Data.EntityFramework;
using HackatonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Test.Helpers;

public static class DbUtilities
{
    public static async Task<int> GetProductRecordCount(ApplicationDbContext db)
    {
        return await db.Products.CountAsync();
    }

    public static void ReinitializeDbForTests(ApplicationDbContext db)
    {
        // throw new Exception(db.ContextId.ToString());
        db.Products.RemoveRange(db.Products);
        InitializeDbForTests(db);
    }

    private static void InitializeDbForTests(ApplicationDbContext db)
    {

        db.Products.AddRange(GetSeedingGenres());
        db.SaveChanges();
    }

    private static List<Product> GetSeedingGenres()
    {
        return new List<Product>()
        {
            new Product(){IUP_code="1", Name="Silla", Description=".", Volume_cm3=10, Zone="A"},
            new Product(){IUP_code="2", Name="Mesa" , Description=".", Volume_cm3=20, Zone="A"},
            new Product(){IUP_code="3", Name="Parlante", Description=".", Volume_cm3=30, Zone="B"}
        };
    }
}

public class SeedDataIds
{
    public List<int> ProductsIds { get; set; }

    public SeedDataIds(List<int> products)
    {
        ProductsIds = products;
    }
}
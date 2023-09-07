
using HackatonApi.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc.Testing;
using Test.Helpers;

namespace Tests;

public partial class ControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ApplicationDbContext _context;
    private readonly SeedDataIds _seedDataIds;

    public ControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _context = DbContextUtilities.GetDbContext(_factory);
        _seedDataIds = DbUtilities.ReinitializeDbForTests(_context);
    }
}


using HackatonApi.Data.EntityFramework;
using Microsoft.AspNetCore.Mvc.Testing;
using Test.Helpers;

namespace Tests;

public partial class ControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly ApplicationDbContext _context;

    public ControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _context = DbContextUtilities.GetDbContext(_factory);
        DbUtilities.ReinitializeDbForTests(_context);
    }

    [Theory]
    [InlineData("/api/product")]
    public async Task Get_AllRecordsReturnSuccess(string url)
    {
        HttpClient client = _factory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
    }
}

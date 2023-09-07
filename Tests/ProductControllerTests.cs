using System.Net;
using Test.Helpers;

namespace Tests;

public partial class ControllerTests
{
    [Fact]
    public async Task When_PostNewProduct_Then_ProductsInDataBaseIncreased()
    {
        HttpClient client = _factory.CreateClient();
        HttpContent product = ProductUtilities.GetProductsHttpContent("1AB", "Atril", ".", 15);
        int counterBefore = await DbUtilities.GetProductRecordCount(_context);

        HttpResponseMessage response = await client.PostAsync("api/product", product);

        int counterAfter = await DbUtilities.GetProductRecordCount(_context);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(counterBefore + 1, counterAfter);

        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.Contains("Almacenado", responseBody);

    }

    [Fact]
    public async Task Get_ByIUPReturnSuccessAndCorrectRecord()
    {
        HttpClient client = _factory.CreateClient();

        HttpResponseMessage response = await client.GetAsync($"api/product/1");

        var responseBody = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        Assert.Contains("Silla", responseBody);
    }
}
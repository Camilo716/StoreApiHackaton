using System.Net;
using HackatonApi.Models;
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

    // [Fact]
    // public async Task Get_ByZoneReturnSuccess()
    // {
    //     HttpClient client = _factory.CreateClient();

    //     HttpResponseMessage response = await client.GetAsync($"api/product/zone/A");

    //     var responseBody = await response.Content.ReadAsStringAsync();
    //     response.EnsureSuccessStatusCode();

    //     List<Product> productList = await ProductUtilities.GetProductModelsFromHttpResponse(response);
    //     Assert.Equal(productList.Count(), 2);
    // }

    // [Fact]
    // public async Task Put_GenreReturnSuccess()
    // {
    //     HttpClient client = _factory.CreateClient();
    //     HttpContent product = ProductUtilities.GetProductsHttpContent(
    //         "2CD", "Butaca", ".", 35
    //     );

    //     HttpResponseMessage response = await client.PutAsync(
    //         $"api/product/1", product);

    //     Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //     var updatedGenre = await ProductUtilities.GetProductModelsFromHttpResponse(response);
    //     Assert.Equal("Butaca", updatedGenre[0].Name);
    // }

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


using System.Text;
using HackatonApi.DTOs;
using HackatonApi.Models;
using Newtonsoft.Json;

internal static class ProductUtilities
{
    internal static HttpContent GetProductsHttpContent(
        string iup, string name, string descripttion, double volume_cm3)
    {
        var product = new ProductCreationDTO
        {
            IUP_code = iup,
            Name = name,
            Description = descripttion,
            Volume_cm3 = volume_cm3
        };

        var jsonContent = JsonConvert.SerializeObject(product);
        HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        return httpContent;
    }

    internal static async Task<List<Product>> GetProductModelsFromHttpResponse(HttpResponseMessage response)
    {
        string responseBody = await response.Content.ReadAsStringAsync();
        List<Product> genreModel = JsonConvert.DeserializeObject<List<Product>>(responseBody);
        return genreModel;
    }
}
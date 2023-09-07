using AutoMapper;
using HackatonApi.Models;
using HackatonApi.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(ProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAsync()
    {
        List<Product> products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }
}
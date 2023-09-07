using AutoMapper;
using HackatonApi.DTOs;
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


    [HttpGet("{uip}", Name = "GetProductByIUP")]
    public async Task<ActionResult<Product>> GetByIdAsync([FromRoute] string uip)
    {
        try
        {
            var product = await _productService.GetProductByUIPAsync(uip);
            return product;
        }
        catch (KeyNotFoundException keyNotFoundEx)
        {
            return NotFound(keyNotFoundEx.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostAsync([FromBody] ProductCreationDTO productCreationDTO)
    {
        Product product = _mapper.Map<Product>(productCreationDTO);
        Product productPosted = await _productService.PostProductAsync(product);

        return Ok(productPosted);
    }

    // [HttpGet("zone/{zoneKey}")]
    // public async Task<ActionResult<List<Product>>> GetByZoneAsync([FromRoute] String zoneKey)
    // {
    //     try
    //     {
    //         List<Product> products = await _productService.GetProductsByZoneAsync(zoneKey);
    //         return products;
    //     }
    //     catch (KeyNotFoundException keyNotFoundEx)
    //     {
    //         return NotFound(keyNotFoundEx.Message);
    //     }
    // }

    [HttpPut("unstore/{id:int}")]
    public async Task<ActionResult<Product>> UnstoreProductAsync(
        [FromRoute] int id, [FromBody] ProductCreationDTO productCreationDTO)
    {
        Product product = _mapper.Map<Product>(productCreationDTO);
        Product productUnstored = await _productService.UnstoreProduct(id, product);
        return Ok(productUnstored);
    }

    [HttpPut("store/{id:int}")]
    public async Task<ActionResult<Product>> StoreProductAsync(
        [FromRoute] int id, [FromBody] ProductCreationDTO productCreationDTO)
    {
        Product product = _mapper.Map<Product>(productCreationDTO);
        Product productUnstored = await _productService.StoreProduct(id, product);
        return Ok(productUnstored);
    }
}
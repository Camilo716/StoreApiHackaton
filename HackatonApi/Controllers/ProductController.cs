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

        // return CreatedAtRoute("GetProductByIUP", new { IUP_code = productPosted.IUP_code }, productPosted);
        return Ok(productPosted);
    }
}
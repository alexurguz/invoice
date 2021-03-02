using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Core.DTOs;
using Invoice.Core.Entities;
using Invoce.Api.Responses;
using Invoice.Core.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductUseCase _productUseCase;
        private readonly IMapper _mapper;

        public ProductController(IProductUseCase productRepository, IMapper mapper)
        {
            _productUseCase = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productUseCase.GetProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            var response = new ApiResponse<IEnumerable<ProductDto>>(productsDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _productUseCase.GetProductById(id);
            var productDto = _mapper.Map<ProductDto>(products);
            var response = new ApiResponse<ProductDto>(productDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productUseCase.InsertProduct(product);
            productDto = _mapper.Map<ProductDto>(product);
            var response = new ApiResponse<ProductDto>(productDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productUseCase.UpdateProduct(product);
            var response = new ApiResponse<Product>(product);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productUseCase.DeleteProduct(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}

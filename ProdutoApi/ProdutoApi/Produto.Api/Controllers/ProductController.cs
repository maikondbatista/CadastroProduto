using Microsoft.AspNetCore.Mvc;
using Products.Domain.Dtos;
using Products.Domain.Interfaces.Services;

namespace Products.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ApiController

    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _service;


        public ProductController(ILogger<ProductController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Método que insere um produto
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var result = await _service.GetProducts(token);
            return await ResponseAsync(result);
        }

        /// <summary>
        /// Método que retorna todos os produtos
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> Post(ProductPostDto dto, CancellationToken token)
        {
            var result = await _service.Post(dto, token);
            return await ResponseAsync(result);
        }

        /// <summary>
        /// Método que altera um produto
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> Put(ProductDto dto, CancellationToken token)
        {
            var result = await _service.Put(dto, token);
            return await ResponseAsync(result);
        }

        /// <summary>
        /// Método que remove um produto
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken token)
        {
            await _service.Delete(id, token);
            return await ResponseAsync("Ok");
        }

        /// <summary>
        /// Método que retorna um produto por id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetById([FromRoute] long id, CancellationToken token)
        {
            var result = await _service.GetById(id, token);
            return await ResponseAsync(result);
        }
    }
}
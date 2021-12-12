using Microsoft.AspNetCore.Mvc;
using Categories.Domain.Dtos;
using Categories.Domain.Interfaces.Services;
using Categories.Api.Configuration;

namespace Categories.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ApiController

    {

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _service;
        private readonly AppSettingsConfig _config;

        public CategoryController(ILogger<CategoryController> logger, AppSettingsConfig config, ICategoryService service)
        {
            _logger = logger;
            _service = service;
            _config = config;
        }

        /// <summary>
        /// Método que retorna todas as categorias
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDto>))]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var result = await _service.GetAll(token);
            return await ResponseAsync(result);
        }

        /// <summary>
        /// Método que insere uma categoria
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDto>))]
        public async Task<IActionResult> Post(CategoryPostDto dto, CancellationToken token)
        {
            var result = await _service.Post(dto, token);
            return await ResponseAsync(result);
        }

        /// <summary>
        /// Método que altera uma categoria
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDto>))]
        public async Task<IActionResult> Put(CategoryDto dto, CancellationToken token)
        {
            var result = await _service.Put(dto, token);
            return await ResponseAsync(result);
        }

        /// <summary>
        /// Método que remove uma categoria
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDto>))]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken token)
        {
            if (await _service.DeleteLinkedProducts(id, _config.UrlProductApi, token))
            {
                await _service.Delete(id, token);

                return await ResponseAsync("Ok");
            }
            else
            {
                return await ResponseAsync("Houve um erro ao excluir a Categoria");
            }
        }

        /// <summary>
        /// Método que retorna uma categoria por id
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
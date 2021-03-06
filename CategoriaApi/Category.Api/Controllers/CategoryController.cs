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
        /// M?todo que retorna todas as categorias
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryBaseDto>))]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var result = await _service.GetAll(token);
            _notifications.AddRange(_service.Validations());
            return await ResponseAsync(result);
        }

        /// <summary>
        /// M?todo que insere uma categoria
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryBaseDto>))]
        public async Task<IActionResult> Post(CategoryPostDto dto, CancellationToken token)
        {
            var result = await _service.Post(dto, token);
            _notifications.AddRange(_service.Validations());
            return await ResponseAsync(result);
        }

        /// <summary>
        /// M?todo que altera uma categoria
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryBaseDto>))]
        public async Task<IActionResult> Put(CategoryPutDto dto, CancellationToken token)
        {
            var result = await _service.Put(dto, token);
            _notifications.AddRange(_service.Validations());
            return await ResponseAsync(result);
        }

        /// <summary>
        /// M?todo que remove uma categoria
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryBaseDto>))]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken token)
        {
            if (await _service.DeleteLinkedProducts(id, _config.UrlProdutoApi, token))
            {
                _notifications.AddRange(_service.Validations());
                if(Valid())
                    await _service.Delete(id, token);

                _notifications.AddRange(_service.Validations());

                return await ResponseAsync();
            }
            else
            {
                return await ResponseAsync("Houve um erro ao excluir a Categoria");
            }
        }

        /// <summary>
        /// M?todo que retorna uma categoria por id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryBaseDto>))]
        public async Task<IActionResult> GetById([FromRoute] long id, CancellationToken token)
        {
            var result = await _service.GetById(id, token);
            _notifications.AddRange(_service.Validations());
            return await ResponseAsync(result);
        }
    }
}
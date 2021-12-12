using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Categories.Domain.Dtos;
using Categories.Domain.Entites;
using Categories.Domain.Interfaces.Repositories;
using Categories.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Categories.Domain.Constants;
using Categories.Domain.Utils.Messages;

namespace Categories.Service.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<Category> _categoryValidator;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;
        private readonly HttpClient _httpClient;

        public CategoryService(ICategoryRepository categoryRepository,
                                 IMapper mapper,
                                 ILogger<CategoryService> logger,
                                 IValidator<Category> categoryValidator,
                                 HttpClient httpClient) : base(categoryRepository, categoryValidator)
        {

            _categoryRepository = categoryRepository;
            _categoryValidator = categoryValidator;
            _mapper = mapper;
            _logger = logger;
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetAll(cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: GetAll");
                AddNotification(Messages.ErrorGetAllCategories);
                return null;
            }
        }

        public async Task<CategoryDto> GetById(long id, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<CategoryDto>(await _categoryRepository.Query().AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: GetById");
                AddNotification(Messages.ErrorFindingById);
                return null;
            }
        }

        public async Task<CategoryDto> Post(CategoryPostDto dto, CancellationToken cancellationToken)
        {
            try
            {
                Category produto = _mapper.Map<Category>(dto);
                await Validate(produto, cancellationToken);

                return _mapper.Map<CategoryDto>(await _categoryRepository.Insert(produto, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Post");
                AddNotification(Messages.ErrorInsertingCategory);
                return null;
            }
        }

        public async Task<CategoryDto> Put(CategoryDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Category>(await GetById(dto.Id, cancellationToken));
                category = _mapper.Map<Category>(dto);
                await _categoryValidator.ValidateAsync(category, cancellationToken);
                await _categoryRepository.Update(category, cancellationToken);
                return _mapper.Map<CategoryDto>(await GetById(category.Id, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Put");
                AddNotification(Messages.ErrorUpdatingCategory);
                return null;
            }
        }

        public async Task Delete(long id, CancellationToken cancellationToken)
        {
            try
            {
                await _categoryRepository.Remove(id, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Delete");
                AddNotification(Messages.ErroDeletingCategoryById);
            }
        }

        public async Task<bool> DeleteLinkedProducts(long id, string urlProductsApi, CancellationToken cancellationToken)
        {
            try
            {
                var Url = urlProductsApi + EndpointConstants.EndpointDeleteByCategory + id;
                var resp = await _httpClient.DeleteAsync(Url, cancellationToken);
                if (resp.IsSuccessStatusCode)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: DeleteLinkedProducts, id: " + id + " urlProductsApi: " + urlProductsApi);
                AddNotification(Messages.ErrorDeletingByCategory);
                return false;
            }
        }

    }
}

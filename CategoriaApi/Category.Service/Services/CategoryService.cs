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
        public async Task<IEnumerable<CategoryBaseDto>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<IEnumerable<CategoryBaseDto>>(await _categoryRepository.GetAll(cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: GetAll");
                AddNotification(Messages.ErrorGetAllCategories);
                return null;
            }
        }

        public async Task<CategoryBaseDto> GetById(long id, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<CategoryBaseDto>(await _categoryRepository.Query().AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: GetById");
                AddNotification(Messages.ErrorFindingById);
                return null;
            }
        }

        public async Task<CategoryBaseDto> Post(CategoryPostDto dto, CancellationToken cancellationToken)
        {
            try
            {
                Category category = _mapper.Map<Category>(dto);
                await Validate(category, cancellationToken);

                return _mapper.Map<CategoryBaseDto>(await _categoryRepository.Insert(category, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Post");
                AddNotification(Messages.ErrorInsertingCategory);
                return null;
            }
        }

        public async Task<CategoryBaseDto> Put(CategoryBaseDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Category>(await GetById(dto.Id, cancellationToken));
                category = _mapper.Map<Category>(dto);
                await _categoryValidator.ValidateAsync(category, cancellationToken);
                await _categoryRepository.Update(category, cancellationToken);
                return _mapper.Map<CategoryBaseDto>(await GetById(category.Id, cancellationToken));
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

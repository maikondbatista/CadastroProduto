using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Products.Domain.Dtos;
using Products.Domain.Entites;
using Products.Domain.Interfaces.Repositories;
using Products.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Products.Service.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IValidator<Product> _productValidator;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private readonly HttpClient _httpClient;

        public ProductService(IProductRepository productRepository,
                                 IMapper mapper,
                                 ILogger<ProductService> logger,
                                 IValidator<Product> productValidator,
                                 HttpClient httpClient) : base(productRepository, productValidator)
        {
            
            _productRepository = productRepository;
            _productValidator = productValidator;
            _mapper = mapper;
            _logger = logger;
            _httpClient = httpClient; 
        } 
        public async Task<IEnumerable<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAll(cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: GetAll");
                throw;
            }
        }

        public async Task<ProductDto> GetById(long id, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<ProductDto>(await _productRepository.Query().AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: GetById");
                throw;
            }
        }

        public async Task<ProductDto> Post(ProductPostDto dto, CancellationToken cancellationToken)
        {
            try
            {
                Product produto = _mapper.Map<Product>(dto);
                await Validate(produto, cancellationToken);

                return _mapper.Map<ProductDto>(await _productRepository.Insert(produto, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Post");
                throw;
            }
        }

        public async Task<ProductDto> Put(ProductDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(await GetById(dto.Id, cancellationToken));
                product = _mapper.Map<Product>(dto);
                await _productValidator.ValidateAsync(product, cancellationToken);
                await _productRepository.Update(product, cancellationToken);
                return _mapper.Map<ProductDto>(await GetById(product.Id, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Put");
                throw;
            }
        }

        public async Task Delete(long id, CancellationToken cancellationToken)
        {
            try
            {
                await _productRepository.Remove(id, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"Método: Delete");
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(CancellationToken token)
        {
            return  _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAll(token));
        }
    }
}


using FluentValidation;
using FluentValidation.Results;
using Products.Domain.Entites.Base;
using Products.Domain.Interfaces.Repositories;

namespace Products.Service.Services
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        private List<ValidationResult> _validations;
        private readonly IRepository<T> _repository;
        private readonly IValidator<T> _validator;

        public BaseService(IRepository<T> repository,
                            IValidator<T> validator)
        {
            _repository = repository;
            _validator = validator;
            _validations = new List<ValidationResult>();
        }

        protected async Task Validate(T obj, CancellationToken cancellationToken) 
        {
           _validations.Add(await _validator.ValidateAsync(obj, cancellationToken));
        }

    }
}

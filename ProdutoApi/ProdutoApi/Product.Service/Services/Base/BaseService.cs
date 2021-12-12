
using FluentValidation;
using FluentValidation.Results;
using Products.Domain.Entites.Base;
using Products.Domain.Interfaces.Repositories;

namespace Products.Service.Services
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        private List<ValidationResult> _validations;
        private List<string> _notifications;
        private readonly IValidator<T> _validator;

        public BaseService(IValidator<T> validator)
        {
            _validator = validator;
            _notifications = new List<string>();
            _validations = new List<ValidationResult>();
        }

        protected async Task Validate(T obj, CancellationToken cancellationToken) 
        {
           _validations.Add(await _validator.ValidateAsync(obj, cancellationToken));
        }

        protected void AddNotification(string notification)
        {
            _notifications?.Add(notification);
        }
    }
}

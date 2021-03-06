
using FluentValidation;
using FluentValidation.Results;
using Categories.Domain.Entites.Base;
using Categories.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace Categories.Service.Services
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        private List<ValidationResult> _validations;
        private readonly IRepository<T> _repository;
        private readonly IValidator<T> _validator;
        private List<string> _notifications;

        public BaseService(IRepository<T> repository,
                            IValidator<T> validator)
        {
            _repository = repository;
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

        public List<string> Validations()
        {
            var validations = new List<string>();
            validations.AddRange(_validations.SelectMany(s => s.Errors).Select(s => s.ErrorMessage).ToList());
            validations.AddRange(_notifications);
            
            return validations;
        }

    }
}

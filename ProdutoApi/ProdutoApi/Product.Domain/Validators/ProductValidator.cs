using FluentValidation;
using Products.Domain.Entites;
using Products.Domain.Utils.Messages;

namespace Products.Domain.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(a => a.Price)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"))
                .Must(preco => preco > 0)
                .WithMessage(Messages.BiggerThanZero("{PropertyName}"));

            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"))
                .MaximumLength(30)
                .WithMessage(Messages.MaximumCharacters("{PropertyName}", 30));

        }
    }
}

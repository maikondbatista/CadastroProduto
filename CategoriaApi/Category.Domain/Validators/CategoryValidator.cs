using FluentValidation;
using Categories.Domain.Entites;
using Categories.Domain.Utils.Messages;

namespace Categories.Domain.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage(Messages.Mandatory("{PropertyName}"))
                .MaximumLength(30)
                .WithMessage(Messages.MaximumCharacters("{PropertyName}", 30));

        }
    }
}

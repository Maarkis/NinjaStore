using FluentValidation;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Helpers;
using NinjaStore.Domain.Resources;

namespace NinjaStore.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(Resource.RequiredDescription.GetDescription())
                .NotNull()
                .WithMessage(Resource.RequiredDescription.GetDescription());

            RuleFor(x => x.Value)
                .NotNull()
                .WithMessage(Resource.RequiredValue.GetDescription())
                .GreaterThan(0)
                .WithMessage(Resource.ValueMustbeGreaterThanZero.GetDescription());

        }
    }
}

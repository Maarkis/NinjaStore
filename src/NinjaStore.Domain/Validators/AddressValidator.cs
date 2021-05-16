using FluentValidation;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Helpers;
using NinjaStore.Domain.Resources;

namespace NinjaStore.Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage(Resource.RequiredNameAddress.GetDescription());
            
            RuleFor(x => x.Cep)
                .NotNull()
                .NotEmpty()
                .WithMessage(Resource.RequiredCep.GetDescription());

            RuleFor(x => x.District)
              .NotNull()
              .NotEmpty()
              .WithMessage(Resource.RequiredDistrict.GetDescription());

            RuleFor(x => x.City)
                .NotNull()
                .NotEmpty()
                .WithMessage(Resource.RequiredCity.GetDescription());

            RuleFor(x => x.State)
                .NotNull()
                .NotEmpty()
                .WithMessage(Resource.RequiredState.GetDescription());

            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .WithMessage(Resource.RequiredNumber.GetDescription());
        }
    }
}

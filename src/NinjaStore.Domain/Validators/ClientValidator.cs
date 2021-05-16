using FluentValidation;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Helpers;
using NinjaStore.Domain.Resources;

namespace NinjaStore.Domain.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(client => client.Name)
                .NotEmpty()
                .WithMessage(Resource.RequiredName.GetDescription())
                .NotNull()
                .WithMessage(Resource.RequiredName.GetDescription());

            RuleFor(client => client.Email)
                .EmailAddress()
                    .WithMessage(Resource.InvalidEmail.GetDescription())
                .NotNull()
                    .WithMessage(Resource.RequiredEmail.GetDescription())
                .NotEmpty()
                    .WithMessage(Resource.RequiredEmail.GetDescription());

            RuleForEach(client => client.Addresses).SetValidator(new AddressValidator());

        }
    }
}

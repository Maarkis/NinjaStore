using FluentValidation;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Helpers;
using NinjaStore.Domain.Resources;
using System;

namespace NinjaStore.Domain.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(order => order.Client).SetValidator(new ClientValidator())
                .NotNull()
                .WithMessage(Resource.OrderWithoutCustomer.GetDescription());

            //RuleFor(order => order.Products)
            //    .NotNull()
            //    .WithMessage(Resource.NoProductsInOrder.GetDescription())
            //    .Must(products => products != null && products.Count > 0)
            //    .WithMessage(Resource.ProductListMustContainAtLeastOne.GetDescription());                
            

            RuleFor(order => order.Amount)                
                .GreaterThan(0)
                .WithMessage(Resource.ValueMustbeGreaterThanZero.GetDescription());

            RuleFor(order => order.Discount)
                .GreaterThan(0)
                .WithMessage(Resource.ValueMustbeGreaterThanZero.GetDescription());

            RuleFor(order => order.Value)
                .GreaterThan(0)
                .WithMessage(Resource.ValueMustbeGreaterThanZero.GetDescription());
            
            RuleFor(order => order.PurchaseDate)
                .NotNull()
                .WithMessage(Resource.RequiredPurchaseDate.GetDescription())
                .LessThan(order => DateTime.Now)
                .WithMessage(Resource.OrderDateHigherThanCurrent.GetDescription());
        }
    }
}

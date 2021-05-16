using ExpectedObjects;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Helpers;
using NinjaStore.Domain.Resources;
using NinjaStore.DomainTest._Builder;
using System;
using Xunit;

namespace NinjaStore.DomainTest.OrderTest
{
    public class OrderTest
    {

        [Fact]
        public void ShouldCreateOrder()
        {
            Order orderExpected = OrderBuilder.NewBuilder().Build();            

            Order order = new Order(orderExpected.Client, orderExpected.Products, orderExpected.Amount, orderExpected.Discount, orderExpected.Value, orderExpected.PurchaseDate);

            orderExpected.ToExpectedObject().ShouldMatch(order);
        }

        [Fact]
        public void ShouldCreateOrderValid()
        {
            Order orderValid = OrderBuilder.NewBuilder().Build();

            Assert.True(orderValid.Valid);
        }

        [Fact]
        public void ShouldCreateOrderInvalid()
        {
            Random random = new Random();
            Order orderInvalid = OrderBuilder.NewBuilder()
                .WithClient(null)
                .WithProducts(ProductBuilder.IsListProduct(0))
                .WithAmount(0)
                .WithDiscount(0)
                .WithValue(0)
                .WithPurchaseDate(DateTime.Now.AddMinutes(random.NextDouble()))
                .Build();

            Assert.True(orderInvalid.Invalid);
        }

        [Fact]
        public void ShouldNotCreateOrderWithInvalidClient()
        {
            Order orderExpected = OrderBuilder.NewBuilder().WithClient(null).Build();            

            var resultErrorMessage = orderExpected.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.OrderWithoutCustomer.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.OrderWithoutCustomer.GetDescription());
        }

        [Fact]
        public void ShouldNotCreateWithInvalidProductsList()
        {
            Order orderExpected = OrderBuilder.NewBuilder().WithProducts(null).Build();

            var resultErrorMessage = orderExpected.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.NoProductsInOrder.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.NoProductsInOrder.GetDescription());
        }

        [Fact]
        public void ShouldNotCreateWithEmptyProductsList()
        {
            Order orderExpected = OrderBuilder
                .NewBuilder()
                .WithProducts(ProductBuilder.IsListProduct(0))
                .Build();

            var resultErrorMessage = orderExpected.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.ProductListMustContainAtLeastOne.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.ProductListMustContainAtLeastOne.GetDescription());
        }



        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-555)]
        [InlineData(-454)]
        public void ShouldNotCreateWithNegativeOrZeroAmount(double valueInvalid)
        {
            Order orderExpected = OrderBuilder
                .NewBuilder()
                .WithAmount(valueInvalid)
                .Build();

            var resultErrorMessage = orderExpected.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.ValueMustbeGreaterThanZero.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.ValueMustbeGreaterThanZero.GetDescription());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-555)]
        [InlineData(-454)]
        public void ShouldNotCreateWithNegativeOrZeroDiscount(double valueInvalid)
        {
            Order orderExpected = OrderBuilder
                .NewBuilder()
                .WithDiscount(valueInvalid)
                .Build();

            var resultErrorMessage = orderExpected.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.ValueMustbeGreaterThanZero.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.ValueMustbeGreaterThanZero.GetDescription());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-20)]
        [InlineData(-1000)]
        public void ShouldNotCreateWithNegativeOrZeroValue(double valueInvalid)
        {
            Order orderExpected = OrderBuilder
                .NewBuilder()
                .WithValue(valueInvalid)
                .Build();

            var resultErrorMessage = orderExpected.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.ValueMustbeGreaterThanZero.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.ValueMustbeGreaterThanZero.GetDescription());
        }

        [Fact]
        public void ShouldNotCreateAnOrderWithADateGreaterThanCurrent()
        {
            Random random = new Random();
            Order orderExpected = OrderBuilder
                .NewBuilder()
                .WithPurchaseDate(DateTime.Now.AddMinutes(random.NextDouble()))
                .Build();

            var resultErrorMessage = orderExpected.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.OrderDateHigherThanCurrent.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.OrderDateHigherThanCurrent.GetDescription());
        }
    }

    
}

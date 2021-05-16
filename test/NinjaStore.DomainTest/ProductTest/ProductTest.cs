using ExpectedObjects;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Helpers;
using NinjaStore.Domain.Resources;
using NinjaStore.DomainTest._Builder;
using Xunit;

namespace NinjaStore.DomainTest.ProductTest
{
    public class ProductTest
    {
        [Fact]
        public void ShouldCreateProduct()
        {
            Product productExpected = ProductBuilder.NewBuilder().Build();

            Product product = new Product(productExpected.Description, productExpected.Value, productExpected.Photo);

            productExpected.ToExpectedObject().ShouldMatch(product);
        }

        [Fact]
        public void ShouldCreateProductValid()
        {
            Product productExpected = ProductBuilder.NewBuilder().Build();        

            Assert.True(productExpected.Valid);
        }

        [Fact]
        public void ShouldCreateProductInvalid()
        {
            Product productExpected = ProductBuilder.NewBuilder().WithDescription(null).WithValue(-1).WithPhoto(null).Build();

            Assert.False(productExpected.Valid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithInvalidDescription(string descriptionInvalid)
        {
            Product productExpected = ProductBuilder.NewBuilder().WithDescription(descriptionInvalid).Build();

            var resultErrorMessage = productExpected.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.RequiredDescription.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.RequiredDescription.GetDescription());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-20)]
        [InlineData(-1000)]
        public void ShouldNotCreateWithNegativeOrZeroValue(double valueInvalid)
        {
            Product productExpected = ProductBuilder.NewBuilder().WithValue(valueInvalid).Build();

            var resultErrorMessage = productExpected.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.ValueMustbeGreaterThanZero.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.ValueMustbeGreaterThanZero.GetDescription());
        }
    }



}

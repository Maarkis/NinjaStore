using ExpectedObjects;
using NinjaStore.Domain.Entities;
using NinjaStore.Domain.Helpers;
using NinjaStore.Domain.Resources;
using NinjaStore.DomainTest._Builder;
using Xunit;

namespace NinjaStore.DomainTest.ClientTest
{
    public class ClientTest
    {

        [Fact]
        public void ShouldCreateClient()
        {
            Client clientExpect = ClientBuilder.NewBuilder().Build();

            Client client = new Client(clientExpect.Name, clientExpect.Email, clientExpect.Addresses);

            clientExpect.ToExpectedObject().ShouldMatch(client);
        }

        [Fact]
        public void ShouldCreateClientValid()
        {           
            Client clientValid = ClientBuilder.NewBuilder().Build();

            Assert.True(clientValid.Valid);
        }

        [Fact]
        public void ShouldCreateClientInvalid()
        {
            
            Client clientInvalid = ClientBuilder.NewBuilder().WithName(null).WithEmail(null).WithAddress(null).Build();

            Assert.True(clientInvalid.Invalid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateWithInvalidName(string nameInvalid)
        {            
            Client clientExpect = ClientBuilder.NewBuilder().WithName(nameInvalid).Build();

            var resultErrorMessage = clientExpect.ValidationResult.Errors.Find(f => f.ErrorMessage == Resource.RequiredName.GetDescription());
            
            Assert.Equal(resultErrorMessage.ErrorMessage, Resource.RequiredName.GetDescription());
        }

        [Theory]
        [InlineData("", Resource.RequiredEmail)]
        [InlineData(null, Resource.RequiredEmail)]
        [InlineData("email invalido", Resource.InvalidEmail)]
        public void ShouldNotCreateWithInvalidEmail(string emailInvalid, Resource assertMessageExpect)
        {            
            Client clientExpect = ClientBuilder.NewBuilder().WithEmail(emailInvalid).Build();

            var resultErrorMessage = clientExpect.ValidationResult.Errors.Find(f => f.ErrorMessage == assertMessageExpect.GetDescription());

            Assert.Equal(resultErrorMessage.ErrorMessage, assertMessageExpect.GetDescription());
        }
    }

}

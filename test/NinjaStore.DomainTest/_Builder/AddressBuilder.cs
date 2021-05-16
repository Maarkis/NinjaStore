using Bogus;
using NinjaStore.Domain.Entities;

namespace NinjaStore.DomainTest._Builder
{
    public class AddressBuilder
    {               
        protected string Name;
        protected string Cep;
        protected string Complement;
        protected string District;
        protected string City;
        protected string Number;
        protected string State;
        
        public static AddressBuilder NewBuilder()
        {
            Faker faker = new Faker();
            return new AddressBuilder
            {
                Name = faker.Address.StreetName(),
                Cep = faker.Address.ZipCode(),
                Complement = faker.Address.SecondaryAddress(),
                District = faker.Address.County(),
                City = faker.Address.City(),
                State = faker.Address.State(),
                Number = faker.Address.BuildingNumber(),
            };
        }

        public Address Build()
        {
            Address address = new Address(Name, Cep, Complement, District, City, State, Number);
            return address;
        }
    }
}

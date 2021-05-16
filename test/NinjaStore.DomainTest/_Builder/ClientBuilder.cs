using Bogus;
using NinjaStore.Domain.Entities;
using System.Collections.Generic;

namespace NinjaStore.DomainTest._Builder
{
    public class ClientBuilder
    {        
        protected string Name;
        protected string Email;
        protected List<Address> Addresses;

        public static ClientBuilder NewBuilder()
        {

            List<Address> addresses = new List<Address>();
            addresses.Add(AddressBuilder.NewBuilder().Build());
            Faker faker = new Faker();
            return new ClientBuilder
            {
                Name = faker.Person.FullName,
                Email = faker.Person.Email,
                Addresses = addresses
            };
        }

        public ClientBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public ClientBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        } 

        public ClientBuilder WithAddress(List<Address> addresses)
        {
            Addresses = addresses;
            return this;
        }

        public Client Build()
        {
            Client client = new Client(Name, Email, Addresses);
            return client;
        }
    }

    
}

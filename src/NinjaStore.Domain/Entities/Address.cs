using NinjaStore.Domain.BaseEntity;

namespace NinjaStore.Domain.Entities
{
    public class Address : Entity
    {
        public string Name { get; private set; }
        public string Cep { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Number { get; private set; }
        public virtual Client Client { get; private set; }
        public int ClientId { get; private set; }

        public Address()
        {                
        }

        public Address(string name, string cep, string complement, string district, string city, string state, string number)
        {
            Name = name;
            Cep = cep;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Number = number;
        }
    }
}

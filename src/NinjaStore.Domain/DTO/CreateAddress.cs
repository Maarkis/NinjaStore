using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStore.Domain.DTO
{
    public class CreateAddress
    {
        public string Name { get; set; }
        public string Cep { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Number { get; set; }        
        
    }
}

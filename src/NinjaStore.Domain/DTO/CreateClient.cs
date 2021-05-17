using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStore.Domain.DTO
{
    public class CreateClient
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<CreateAddress> Address { get; set; }
    }
}

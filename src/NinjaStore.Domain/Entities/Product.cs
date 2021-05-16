using NinjaStore.Domain.BaseEntity;
using NinjaStore.Domain.Validators;
using System.Collections.Generic;

namespace NinjaStore.Domain.Entities
{
    public class Product : BaseEntityByGuid
    {
        public string Description { get; private set; }
        public double Value { get; private set; }
        public string Photo { get; private set; }
        public virtual ICollection<OrderProduct> Orders { get; set; }
        public Product(string description, double value, string photo)
        {
            Description = description;
            Value = value;
            Photo = photo;            

            Validate(this, new ProductValidator());
        }
    }
}

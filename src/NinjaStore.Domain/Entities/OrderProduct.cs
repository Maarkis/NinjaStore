using NinjaStore.Domain.BaseEntity;
using System;

namespace NinjaStore.Domain.Entities
{
    public class OrderProduct : Entity
    {
        public int OrderProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}

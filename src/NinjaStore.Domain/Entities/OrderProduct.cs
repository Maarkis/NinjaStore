using NinjaStore.Domain.BaseEntity;
using System;

namespace NinjaStore.Domain.Entities
{
    public class OrderProduct : BaseEntityByGuid
    {
        public Guid OrderProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}

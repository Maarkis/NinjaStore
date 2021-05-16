using NinjaStore.Domain.BaseEntity;
using NinjaStore.Domain.Validators;
using System;
using System.Collections.Generic;

namespace NinjaStore.Domain.Entities
{
    public class Order : BaseEntityBySequential
    {
        public virtual Client Client { get; private set; }        
        public double Amount { get; private set; }
        public double Discount { get; private set; }
        public double Value { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public virtual ICollection<OrderProduct> Products { get; private set; }

        public Order(Client client, ICollection<OrderProduct> products, double amount, double discount, double value, DateTime purchaseDate)
        {
            Client = client;
            Products = products;
            Amount = amount;
            Discount = discount;
            Value = value;
            PurchaseDate = purchaseDate;

            Validate(this, new OrderValidator());
        }
    }
}

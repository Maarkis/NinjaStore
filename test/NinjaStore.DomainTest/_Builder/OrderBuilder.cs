using NinjaStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjaStore.DomainTest._Builder
{
    public class OrderBuilder
    {
        protected Client Client;
        protected ICollection<OrderProduct> Products;
        protected double Amount;
        protected double Discount;
        protected double Value;
        protected DateTime PurchaseDate;

        public static OrderBuilder NewBuilder()
        {
            Client client = ClientBuilder.NewBuilder().Build();
            ICollection<OrderProduct> products = ProductBuilder.IsListProduct();
            Double amount = products.Select(x => x.Product.Value).Sum();
            Double discount = ((amount * 10) / 100);
            Double value = (amount - discount);
            DateTime purchaseDate = DateTime.Now;

            return new OrderBuilder
            {
                Client = client,
                Products = products,
                Amount = amount,
                Discount = discount,
                Value = value,
                PurchaseDate = purchaseDate
            };
        }

        public OrderBuilder WithClient(Client client)
        {
            Client = client;
            return this;
        }

        public OrderBuilder WithProducts(ICollection<OrderProduct> products)
        {
            Products = products;
            return this;
        }

        public OrderBuilder WithAmount(double amount)
        {
            Amount = amount;
            return this;
        }
        
        public OrderBuilder WithDiscount(double discount)
        {
            Discount = discount;
            return this;
        }

        public OrderBuilder WithValue(double value)
        {
            Value = value;
            return this;
        }

        public OrderBuilder WithPurchaseDate(DateTime purchaseDate)
        {
            PurchaseDate = purchaseDate;
            return this;
        }
        
        public Order Build()
        {
            Order order = new Order(Client, Products, Amount, Discount, Value, PurchaseDate);
            return order;
        }
    }
}

using Bogus;
using NinjaStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NinjaStore.DomainTest._Builder
{
    public class ProductBuilder
    {
        protected int Id;
        protected string Description;
        protected double Value;
        protected string Photo;

        public static ProductBuilder NewBuilder()
        {
            Faker faker = new Faker();
            return new ProductBuilder
            {
                Description = faker.Lorem.Paragraph(),
                Value = faker.Random.Double(1),
                Photo = faker.Lorem.Paragraph(),
            };
        }

        public ProductBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public ProductBuilder WithValue(double value)
        {
            Value = value;
            return this;
        }

        public ProductBuilder WithPhoto(string photo)
        {
            Photo = photo;
            return this;
        }

        public ProductBuilder WithId(int id)
        {
            Id = id;
            return this;
        }

        
        public static ICollection<OrderProduct> IsListProduct(int amount = 1)
        {
            ICollection<OrderProduct> orderProducts = new Collection<OrderProduct>();
            for (int i=0; i < amount; i++)
            {

                Product product = NewBuilder().Build();
                Order order = OrderBuilder.NewBuilder().Build();
                OrderProduct orderProduct = new OrderProduct
                {
                    Id = new Guid(),
                    OrderId = i,
                    Order = order,
                    Product = product,
                    ProductId = new Guid()                   

                };

                orderProducts.Add(orderProduct);
            }
            
            return orderProducts;
        }

        public Product Build()
        {
            Product product = new Product(Description, Value, Photo);
            return product;
        }
    }
}

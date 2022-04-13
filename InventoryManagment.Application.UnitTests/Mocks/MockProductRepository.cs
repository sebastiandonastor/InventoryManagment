using InventoryManagment.Application.DTOs;
using InventoryManagment.Application.Persistence.Contracts;
using InventoryManagment.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace InventoryManagment.Application.UnitTests.Mocks
{
    public class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Dog's Toy"
                },
                new Product
                {
                    Id = 2,
                    Name = "Dog's Food"
                },
                new Product
                {
                    Id = 3,
                    Name = "Dog's Bed"
                }
            };

            var mockRepo = new Mock<IProductRepository>();

            mockRepo
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(products);

            mockRepo
                .Setup(r => r.AnyAsync(It.IsAny<Expression<Func<Product, bool>>>(), default))
                .ReturnsAsync((Expression<Func<Product, bool>> predicate,CancellationToken _) =>
                {
                    return products.Any(predicate.Compile());
                });

            mockRepo
                .Setup(r => r.AddAsync(It.IsAny<Product>(), default))
                .ReturnsAsync((Product product, CancellationToken _) =>
            {
                products.Add(product);
                return product;
            });



            return mockRepo;

        }
    }
}

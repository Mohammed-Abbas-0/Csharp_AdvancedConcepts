using DataLogic.Entities;

namespace DataLogic.StaticData;
public static class SeedData
{
    public static List<Product> Products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 999.99m,
            InStock = true,
            CreatedDate = DateTime.UtcNow.AddDays(-10),
            CategoryId = 1
        },
        new Product
        {
            Id = 2,
            Name = "Smartphone",
            Price = 699.99m,
            InStock = true,
            CreatedDate = DateTime.UtcNow.AddDays(-5),
            CategoryId = 1
        },
        new Product
        {
            Id = 3,
            Name = "Desk Chair",
            Price = 89.99m,
            InStock = false,
            CreatedDate = DateTime.UtcNow.AddDays(-20),
            CategoryId = 2
        }
    };

    public static List<Category> Categories = new()
    {
        new Category
        {
            Id = 1,
            Name = "Electronics"
        },
        new Category
        {
            Id = 2,
            Name = "Furniture"
        }
    };
    public static List<Review> Reviews = new()
    {
        new Review
        {
            Id = 1,
            ProductId = 1,
            Rating = 5,
            Comment = "Excellent laptop with great performance."
        },
        new Review
        {
            Id = 2,
            ProductId = 2,
            Rating = 4,
            Comment = "Good smartphone but battery life could be better."
        },
        new Review
        {
            Id = 3,
            ProductId = 3,
            Rating = 3,
            Comment = "Average chair, not very comfortable."
        }
    };
}

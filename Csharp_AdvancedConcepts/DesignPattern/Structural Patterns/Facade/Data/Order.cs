namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public required string CustomerEmail { get; set; }
        public required string CardNumber { get; set; }
       
    }
    public static class OrderData
    {
        public static List<Order> Orders = new List<Order>()
        {
            new Order { OrderId = 1, ProductId = 101, Quantity = 2, TotalAmount = 49.98m, CustomerEmail = "test", CardNumber="1234-5678-9012-3456" },
            new Order { OrderId = 2, ProductId = 102, Quantity = 1, TotalAmount = 19.99m, CustomerEmail = "example", CardNumber="9876-5432-1098-7654" },
            new Order { OrderId = 3, ProductId = 103, Quantity = 5, TotalAmount = 99.95m, CustomerEmail = "sample", CardNumber="4567-8901-2345-6789" }

        };
    }

}

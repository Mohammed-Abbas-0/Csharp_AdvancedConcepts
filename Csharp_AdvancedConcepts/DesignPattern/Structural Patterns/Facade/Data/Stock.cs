namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Data
{
    public class Stock
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public required string ProductName { get; set; }
    }
   public static class StockData
    {
        public static List<Stock> Stocks = new List<Stock>
        {
            new Stock { ProductId = 101, ProductName = "Laptop", Quantity = 50 },
            new Stock { ProductId = 102, ProductName = "Smartphone", Quantity = 150 },
            new Stock { ProductId = 103, ProductName = "Tablet", Quantity = 75 }
        };
    }
}

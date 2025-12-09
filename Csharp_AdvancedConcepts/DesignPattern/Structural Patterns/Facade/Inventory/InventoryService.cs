using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facad.inventory;
using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Data;

namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Inventory
{
    public class InventoryService : IInventoryService
    {
        public bool CheckStock(int productId)
        {
            if (productId <= 0)
            {
                throw new ArgumentException("Invalid product ID");
            }
            var product = StockData.Stocks.FirstOrDefault(p => p.ProductId == productId);
            if (product != null && product.Quantity > 0)
            {
                return true;
            }
            return false;
        }

        public void ReserveStock(int productId, decimal quantity)
        {
            var product = StockData.Stocks.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }
            if (product.Quantity < quantity)
            {
                throw new InvalidOperationException("Insufficient stock");
            }
            product.Quantity -= quantity;
            Console.WriteLine($"Reserved {quantity} of {product.ProductName}. Remaining stock: {product.Quantity}");
        }
    }
}

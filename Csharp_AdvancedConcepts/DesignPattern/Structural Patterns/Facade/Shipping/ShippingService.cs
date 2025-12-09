namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Shipping
{
    internal class ShippingService : IShippingService
    {
        public void GenerateShippingLabel(int orderId)
        {
            Console.WriteLine($"Shipping label generated for Order ID: {orderId}");
        }

        public string SchedulePickup(int orderId)
        {
            return $"Pickup scheduled for Order ID: {orderId} on {DateTime.Now.AddDays(1):d}";
        }
    }
}

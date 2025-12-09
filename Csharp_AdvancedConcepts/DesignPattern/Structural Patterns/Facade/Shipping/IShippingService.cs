namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Shipping
{
    public interface IShippingService
    {
        void GenerateShippingLabel(int orderId);

        string SchedulePickup(int orderId);
    }
}

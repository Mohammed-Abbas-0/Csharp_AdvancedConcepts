namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facad.inventory;
    public interface IInventoryService
    {
        bool CheckStock(int productId);

        void ReserveStock(int productId, decimal quantity);
    }


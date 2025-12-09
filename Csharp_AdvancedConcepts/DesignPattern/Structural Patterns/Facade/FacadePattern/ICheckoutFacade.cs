using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Data;

namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.FacadePattern
{
    public interface ICheckoutFacade
    {
        public CheckoutResult ProcessOrder(Order order);

    }
}

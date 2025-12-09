namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Payment
{
    public interface IPaymentService
    {
        bool ValidateCard(string cardNumber);

        void Charge(decimal amount);
    }
}

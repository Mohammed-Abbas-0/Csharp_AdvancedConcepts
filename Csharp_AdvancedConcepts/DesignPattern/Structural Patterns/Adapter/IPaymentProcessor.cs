namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Adapter
{
    // الواجهة الموحدة التي يتوقعها النظام الجديد
    // The unified interface that the new system expects
    public interface IPaymentProcessor
    {
        bool ProcessPayment(string customerName, decimal amount);
        string GetPaymentStatus(string transactionId);
    }
}

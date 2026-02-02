namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Adapter
{
    // نظام دفع حديث يتوافق مع الواجهة المطلوبة
    // Modern payment gateway that implements the required interface
    public class ModernPaymentGateway : IPaymentProcessor
    {
        public bool ProcessPayment(string customerName, decimal amount)
        {
            Console.WriteLine($"[Modern Gateway] Processing payment for {customerName}");
            Console.WriteLine($"[Modern Gateway] Amount: {amount:C}");

            // محاكاة معالجة الدفع
            // Simulate payment processing
            Thread.Sleep(500);

            Console.WriteLine($"[Modern Gateway] Payment completed successfully!");
            return true;
        }

        public string GetPaymentStatus(string transactionId)
        {
            Console.WriteLine($"[Modern Gateway] Checking status for: {transactionId}");
            return "Completed";
        }
    }
}

namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Adapter
{
    // المحول الذي يربط النظام القديم بالواجهة الجديدة
    // The adapter that bridges the legacy system with the new interface
    public class PaymentAdapter : IPaymentProcessor
    {
        private readonly LegacyPaymentSystem _legacySystem;
        private string _lastTransactionId = string.Empty;

        public PaymentAdapter(LegacyPaymentSystem legacySystem)
        {
            _legacySystem = legacySystem;
        }

        public bool ProcessPayment(string customerName, decimal amount)
        {
            Console.WriteLine("\n[Adapter] Converting new system call to legacy format...");

            // تحويل decimal إلى string كما يتوقع النظام القديم
            // Convert decimal to string as expected by legacy system
            string amountStr = amount.ToString("F2");

            // استدعاء النظام القديم
            // Call the legacy system
            _lastTransactionId = _legacySystem.MakePayment(customerName, amountStr);

            // تحويل النتيجة من النظام القديم إلى النتيجة المتوقعة
            // Convert legacy result to expected format
            int statusCode = _legacySystem.CheckStatus(_lastTransactionId);

            bool success = statusCode == 1;
            Console.WriteLine($"[Adapter] Conversion complete. Success: {success}\n");

            return success;
        }

        public string GetPaymentStatus(string transactionId)
        {
            Console.WriteLine("\n[Adapter] Converting status check to legacy format...");

            // تحويل رمز الحالة إلى نص
            // Convert status code to text
            int statusCode = _legacySystem.CheckStatus(transactionId);

            string status = statusCode switch
            {
                0 => "Failed",
                1 => "Completed",
                2 => "Pending",
                _ => "Unknown"
            };

            Console.WriteLine($"[Adapter] Status converted: {status}\n");
            return status;
        }
    }
}

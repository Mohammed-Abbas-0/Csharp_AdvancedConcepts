namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Adapter
{
    // النظام القديم الذي لا يمكن تعديله
    // The legacy system that cannot be modified
    public class LegacyPaymentSystem
    {
        public string MakePayment(string name, string amountStr)
        {
            Console.WriteLine($"[Legacy System] Processing payment for {name}");
            Console.WriteLine($"[Legacy System] Amount: {amountStr} EGP");

            // محاكاة معالجة الدفع
            // Simulate payment processing
            Thread.Sleep(500);

            string transId = $"LEG-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
            Console.WriteLine($"[Legacy System] Transaction ID: {transId}");

            return transId;
        }

        public int CheckStatus(string transactionId)
        {
            Console.WriteLine($"[Legacy System] Checking status for: {transactionId}");

            // النظام القديم يرجع رموز: 0 = فشل، 1 = نجاح، 2 = معلق
            // Legacy system returns codes: 0 = failed, 1 = success, 2 = pending
            return 1; // Success
        }
    }
}

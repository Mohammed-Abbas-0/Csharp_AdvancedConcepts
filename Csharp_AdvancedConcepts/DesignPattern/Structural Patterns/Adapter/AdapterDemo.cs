namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Adapter
{
    // فئة العرض التوضيحي
    // Demo class
    public class AdapterDemo
    {
        public static void Run()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("          Adapter Pattern Demo - نمط المحول");
            Console.WriteLine("═══════════════════════════════════════════════════════════\n");

            // إنشاء قائمة من معالجات الدفع
            // Create a list of payment processors
            List<IPaymentProcessor> paymentProcessors = new List<IPaymentProcessor>();

            // إضافة النظام الحديث
            // Add modern system
            paymentProcessors.Add(new ModernPaymentGateway());

            // إضافة النظام القديم من خلال المحول
            // Add legacy system through adapter
            LegacyPaymentSystem legacySystem = new LegacyPaymentSystem();
            paymentProcessors.Add(new PaymentAdapter(legacySystem));

            // معالجة الدفعات باستخدام نفس الواجهة
            // Process payments using the same interface
            decimal amount = 1500.50m;
            string customer = "Ahmed Mohamed";

            Console.WriteLine("───────────────────────────────────────────────────────────");
            Console.WriteLine("Test 1: Using Modern Payment Gateway");
            Console.WriteLine("───────────────────────────────────────────────────────────");
            ProcessTransaction(paymentProcessors[0], customer, amount);

            Console.WriteLine("\n───────────────────────────────────────────────────────────");
            Console.WriteLine("Test 2: Using Legacy System via Adapter");
            Console.WriteLine("───────────────────────────────────────────────────────────");
            ProcessTransaction(paymentProcessors[1], customer, amount);

            Console.WriteLine("\n═══════════════════════════════════════════════════════════");
            Console.WriteLine("           Demo Completed - انتهى العرض");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
        }

        private static void ProcessTransaction(IPaymentProcessor processor, string customer, decimal amount)
        {
            // معالجة الدفع
            // Process payment
            bool result = processor.ProcessPayment(customer, amount);

            if (result)
            {
                Console.WriteLine($"✓ Payment processed successfully!");
            }
            else
            {
                Console.WriteLine($"✗ Payment failed!");
            }
        }
    }
}

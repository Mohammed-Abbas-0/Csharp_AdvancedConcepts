namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Invoice
{
    internal class InvoiceService : IInvoiceService
    {
        public void CreateInvoice(int orderId, decimal amount)
        {
           Console.WriteLine($"Invoice created for Order ID: {orderId} with Amount: {amount}");
        }
    }
}

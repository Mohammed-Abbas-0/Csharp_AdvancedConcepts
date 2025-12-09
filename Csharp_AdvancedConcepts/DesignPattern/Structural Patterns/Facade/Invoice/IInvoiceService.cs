namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Invoice
{
    public interface IInvoiceService
    {
        void CreateInvoice(int orderId,decimal amount);
    }
}

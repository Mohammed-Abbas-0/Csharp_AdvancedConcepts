namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Email
{
    public interface IEmailService
    {
        void SendOrderConfirmation(string email,int orderId);
    }
}

namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Email
{
    public class EmailService : IEmailService
    {
        public void SendOrderConfirmation(string email, int orderId)
        {
            Console.WriteLine($"Order confirmation email sent to {email} for Order ID: {orderId}");
        }
    }
}

namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Payment
{
    public class PaymentService : IPaymentService
    {
        public void Charge(decimal amount)
        {
            Console.WriteLine($"Charged amount: {amount}");
        }

        public bool ValidateCard(string cardNumber)
        {
            if(string.IsNullOrEmpty(cardNumber))
            {
                return false;
            }
            // need remove dashes from card number
            string card = cardNumber.Replace("-", "");
            return  card.Length == 16;
        }
    }
}

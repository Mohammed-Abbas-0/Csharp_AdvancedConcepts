namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Data
{
    public class CheckoutResult
    {
        public int OrderId { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}

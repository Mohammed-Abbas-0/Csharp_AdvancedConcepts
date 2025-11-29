namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Decorator
{
    // Concrete Component
    public class EmailNotificationConcrete:INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email: " + message);
        }
    }
}

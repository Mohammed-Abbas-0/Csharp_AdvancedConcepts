namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Decorator
{
    public class SMSDecorator:NotificationDecorator
    {
        public SMSDecorator(INotification not):base(not)
        {
            
        }
        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine("SMS: " + message);
        }
    }
}

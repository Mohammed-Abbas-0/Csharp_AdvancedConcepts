namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Decorator
{
    public abstract class NotificationDecorator
    {
        private readonly INotification _notification;
        public NotificationDecorator(INotification notification)
        {
            _notification = notification;
        }
        public virtual void Send(string message)
        {
            // Additional behavior can be added here
            Console.WriteLine("Decorator: Before sending notification.");
            _notification.Send(message);
            Console.WriteLine("Decorator: After sending notification.");
        }
    }
}

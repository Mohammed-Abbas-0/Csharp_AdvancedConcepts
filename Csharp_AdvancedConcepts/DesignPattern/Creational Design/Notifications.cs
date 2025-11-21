namespace Csharp_AdvancedConcepts.DesignPattern.Creational_Design
{
    public interface INotifications
    {
        void Send(string message);
    }
    public class EmailNotification : INotifications
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email Notification: {message}");
        }
    }
    public class SMSNotification : INotifications
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS Notification: {message}");
        }
    }
    public class PushNotification : INotifications
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Push Notification: {message}");
        }
    }
    public enum NotificationType
    {
        Email,
        SMS,
        Push
    }

    public static class NotificationFactoryMethod
    {
        public static INotifications CreateNotification(NotificationType type, INotificationFactory environmentFactory)
        {
            return type switch
            {
                NotificationType.Email => environmentFactory.CreateEmail(),
                NotificationType.SMS => environmentFactory.CreateSMS(),
                NotificationType.Push => environmentFactory.CreatePush(),
                _ => throw new ArgumentException("Invalid Notification Type"),
            };
        }
    }

    // Abstract Factory Pattern could be implemented here if we had multiple related notification families
    public interface INotificationFactory
    {
        INotifications CreateEmail();
        INotifications CreateSMS();
        INotifications CreatePush();
    }

    public class ProductionNotificationFactory : INotificationFactory
    {
        public INotifications CreateEmail() => new EmailNotification();
        public INotifications CreateSMS() => new SMSNotification();
        public INotifications CreatePush() => new PushNotification();
    }


    public class StagingNotificationFactory : INotificationFactory
    {
        public INotifications CreateEmail() => new FakeEmailNotification();
        public INotifications CreateSMS() => new ConsoleSmsNotification();
        public INotifications CreatePush() => new DummyPushNotification();
    }
    public class DevNotificationFactory : INotificationFactory
    {
        public INotifications CreateEmail() => new DevEmailNotification();
        public INotifications CreateSMS() => new DevSMSNotification();
        public INotifications CreatePush() => new DevPushNotification();
    }

    public class FakeEmailNotification : INotifications
    {
        public void Send(string message)
        {
            Console.WriteLine($"[STAGING] Fake Email Logged: {message}");
        }
    }

    public class ConsoleSmsNotification : INotifications
    {
        public void Send(string message)
        {
            Console.WriteLine($"[STAGING] Console SMS Logged: {message}");
        }
    }

    public class DummyPushNotification : INotifications
    {
        public void Send(string message)
        {
            Console.WriteLine($"[STAGING] Dummy Push Logged: {message}");
        }
    }
    public class DevEmailNotification : INotifications
    {
        public void Send(string message)
        {
            Console.WriteLine($"[DEV] Email -> {message}");
        }
    }

    public class DevSMSNotification : INotifications
    {
        public void Send(string message)
        {
            Console.WriteLine($"[DEV] SMS -> {message}");
        }
    }

    public class DevPushNotification : INotifications
    {
        public void Send(string message)
        {
            Console.WriteLine($"[DEV] Push -> {message}");
        }
    }

}

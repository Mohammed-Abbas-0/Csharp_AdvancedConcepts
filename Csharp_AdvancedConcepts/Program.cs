using Csharp_AdvancedConcepts.DesignPattern.Creational_Design;
using Csharp_AdvancedConcepts.DesignPattern.Singleton;
using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Decorator;

//// Transport Factory Usage
//var factory = new TransportFactory();

//Console.WriteLine("Enter transport type (Air, Sea, Road): ");
//var input = Console.ReadLine();

//try
//{
//    // تحويل الديناميك من string إلى Enum
//    var type = Enum.Parse<TransportType>(input, ignoreCase: true);

//    // إنشاء النوع المناسب
//    var transport = factory.Create(type);

//    // تشغيل العملية
//    transport.Deliver();
//}
//catch
//{
//    Console.WriteLine("Invalid transport type 😢");
//}

//Console.ReadLine();


//// Waybill Printer Factory Usage

//var waybillFactory = new WaybillTypeFactory();

//Console.WriteLine("Enter waybill printer type (1: PDF, 2: Excel, 3: Word): ");
//var waybillEnum = Console.ReadLine();

//try
//{
//    // إنشاء النوع المناسب
//    var waybillCreater = waybillFactory.Create(int.Parse(waybillEnum!));

//    // تشغيل العملية
//    waybillCreater.Print();
//}
//catch
//{
//    Console.WriteLine("Invalid transport type 😢");
//}

//Console.ReadLine();



/*

using Csharp_AdvancedConcepts.DesignPattern.AbstractFactory;

Console.Write("Enter mode (local/international): ");
var mode = Console.ReadLine()?.ToLower();

ITransportFactory factory = mode switch
{
    "local" => new LocalTransportFactory(),
    "international" => new InternationalTransportFactory(),
    _ => throw new Exception("Invalid mode")
};

var heavy = factory.CreateHeavyTransport();
var light = factory.CreateLightTransport();

heavy.Deliver();
light.Deliver();
*/


#region Builder Pattern Example

/// <summary>
/// Builder Pattern Example
/// Use the PizzaBuilder to create a Pizza object step by step.
/// </summary>
//
/*
using Csharp_AdvancedConcepts.DesignPattern.Builder;

Console.WriteLine("Building a Pizza using Builder Pattern...");
Console.WriteLine("Select Pizza Size (Small, Medium, Large): ");
var sizeInput = Console.ReadLine();


var size = Enum.Parse<PizzaSize>(sizeInput!, ignoreCase: true);
Console.WriteLine("Select Pizza Crust (Thin, Thick, Stuffed): ");
var crustInput = Console.ReadLine();
var crust = Enum.Parse<PizzaCrust>(crustInput!, ignoreCase: true);
Console.WriteLine("Take Away? (yes/no): ");
var takeAwayInput = Console.ReadLine();
var takeAway = takeAwayInput!.ToLower() == "yes" ? TakeAwayOption.Yes : TakeAwayOption.No;



var pizza = new PizzaBuilder()
                .WithSize(size)
                .WithCrust(crust)
                .AddTopping(new List<string> { "Cheese" })
                .WithSauce(new List<string> { "Tomato" })
                .TakeAway(takeAway)
                .Build();


Console.WriteLine("\nPizza Details:");
Console.WriteLine($"Size: {pizza.Size} && Crust: {pizza.Crust} && takeAway: {(pizza.TakeAway == true ? "Yes" : "No")}");
*/
//
#endregion

#region Singleton Pattern Example

Console.WriteLine("--- Singleton Pattern Example ---");

// Accessing the instance for the first time
Console.WriteLine("Accessing Instance 1...");
var instance1 = Singleton.Instance;
instance1.DoSomething();

// Accessing the instance for the second time
Console.WriteLine("Accessing Instance 2...");
var instance2 = Singleton.Instance;
instance2.DoSomething();

// Verifying that both variables point to the same instance
if (ReferenceEquals(instance1, instance2))
{
    Console.WriteLine("Result: Both variables contain the same instance.");
}
else
{
    Console.WriteLine("Result: Variables contain different instances (Error).");
}

#endregion

#region Abstract Factory Pattern Example
// Choose Environment
INotificationFactory envFactory = new StagingNotificationFactory();
// Or: new ProductionNotificationFactory();
// Or: new DevNotificationFactory();

// Choose the specific Notification type
var notification = NotificationFactoryMethod.CreateNotification(NotificationType.Email, envFactory);

notification.Send("Hello from Design Patterns!");
#endregion

#region Decorator Pattern Example
var notificationEmail = new EmailNotificationConcrete();
Console.WriteLine("\n--- Basic Email Notification ---");
notificationEmail.Send("This is a basic email notification.");
var decoratedNotification = new SMSDecorator(notificationEmail);
Console.WriteLine("\n--- Decorated Notification (Email + SMS) ---");
decoratedNotification.Send("This is a decorated notification with SMS.");

#endregion
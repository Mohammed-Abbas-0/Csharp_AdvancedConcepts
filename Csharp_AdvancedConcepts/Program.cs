using Csharp_AdvancedConcepts.DesignPattern.Creational_Design;
using Csharp_AdvancedConcepts.DesignPattern.Singleton;
using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Decorator;
using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Data;


/*
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
*/

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

/*
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
*/

/*
#region Abstract Factory Pattern Example
// Choose Environment
INotificationFactory envFactory = new StagingNotificationFactory();
// Or: new ProductionNotificationFactory();
// Or: new DevNotificationFactory();

// Choose the specific Notification type
var notification = NotificationFactoryMethod.CreateNotification(NotificationType.Email, envFactory);

notification.Send("Hello from Design Patterns!");
#endregion
*/

/*
#region Decorator Pattern Example
var notificationEmail = new EmailNotificationConcrete();
Console.WriteLine("\n--- Basic Email Notification ---");
notificationEmail.Send("This is a basic email notification.");
var decoratedNotification = new SMSDecorator(notificationEmail);
Console.WriteLine("\n--- Decorated Notification (Email + SMS) ---");
decoratedNotification.Send("This is a decorated notification with SMS.");

#endregion

*/


/*
#region Facade Pattern Example

using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.FacadePattern;

ICheckoutFacade checkoutFacade = new CheckoutFacade();
var order = OrderData.Orders.FirstOrDefault();
var result = checkoutFacade.ProcessOrder(order!);

if (result.IsSuccessful)
    Console.WriteLine("Order placed successfully!");
else
    Console.WriteLine("Order failed: " + result.ErrorMessage);


#endregion
*/

#region Adapter Pattern Example

using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Adapter;
using System;
using DataLogic.Entities;
using DataLogic.Enum;
using DataLogic.StaticData;
using DataLogic.FilterSystem;



var product = new ProductValid() { Name = "a",Price = 500 };
var result = ValidHelper<ProductValid>.Validate(product);
if (!result.IsValid)
{
    Console.WriteLine("Validation Failed:");
    foreach (var error in result.Errors)
    {
        Console.WriteLine($"  - {error.PropertyName}: {error.Message}");
    }
}
else
{
    Console.WriteLine("✓ Valid!");
}


AdapterDemo.Run();

#endregion


#region Expression && Refliection Example
Console.WriteLine("╔══════════════════════════════════════════╗");
Console.WriteLine("║   Dynamic Filter System - Test Suite    ║");
Console.WriteLine("╔══════════════════════════════════════════╗\n");

// Test 1: Basic Equals
Test1_BasicEquals();
/*
// Test 2: Price Greater Than
Test2_PriceGreaterThan();

// Test 3: Price Less Than
Test3_PriceLessThan();

// Test 4: String Contains
Test4_StringContains();

// Test 5: String StartsWith
Test5_StringStartsWith();

// Test 6: String EndsWith
Test6_StringEndsWith();

// Test 7: Multiple Conditions (AND)
Test7_MultipleConditions();

// Test 8: InStock Filter
Test8_InStockFilter();

// Test 9: Date Filtering
Test9_DateFiltering();

// Test 10: Complex Query
Test10_ComplexQuery();
*/

var f = new FilterBuilder<Product>();
var expression = f.BuildGreater("Price", 500.0);
var results = SeedData.Products.AsQueryable().Where(expression).ToList();
foreach (var p in results)
{
    Console.WriteLine($"  ✓ {p.Name} - {p.Price:C}");
}

Console.WriteLine("\n╔══════════════════════════════════════════╗");
Console.WriteLine("║         All Tests Completed! ✓           ║");
Console.WriteLine("╚══════════════════════════════════════════╝");
static void Test1_BasicEquals()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 1: Basic Equals - Category Electronics");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.CategoryId), FilterOperation.Equals, 1);

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name} - {p.Price:C} (CategoryId: {p.CategoryId})");
    }
    Console.WriteLine();
}
/*
static void Test2_PriceGreaterThan()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 2: Price Greater Than 500");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.Price), FilterOperation.GreaterThan, 500m);

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name} - {p.Price:C}");
    }
    Console.WriteLine();
}

static void Test3_PriceLessThan()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 3: Price Less Than 100");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.Price), FilterOperation.LessThan, 100m);

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name} - {p.Price:C}");
    }
    Console.WriteLine();
}

static void Test4_StringContains()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 4: Name Contains 'top'");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.Name), FilterOperation.Contains, "top");

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name}");
    }
    Console.WriteLine();
}

static void Test5_StringStartsWith()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 5: Name Starts With 'S'");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.Name), FilterOperation.StartsWith, "S");

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name}");
    }
    Console.WriteLine();
}

static void Test6_StringEndsWith()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 6: Name Ends With 'Chair'");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.Name), FilterOperation.EndsWith, "Chair");

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name}");
    }
    Console.WriteLine();
}

static void Test7_MultipleConditions()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 7: Electronics AND Price > 600");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.CategoryId), FilterOperation.Equals, 1)
        .AddCondition(nameof(Product.Price), FilterOperation.GreaterThan, 600m);

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name} - {p.Price:C} (Cat: {p.CategoryId})");
    }
    Console.WriteLine();
}

static void Test8_InStockFilter()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 8: Products In Stock");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.InStock), FilterOperation.Equals, true);

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name} - In Stock: {p.InStock}");
    }
    Console.WriteLine();
}

static void Test9_DateFiltering()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 9: Products Created in Last 7 Days");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.CreatedDate), FilterOperation.GreaterThan, sevenDaysAgo);

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name} - Created: {p.CreatedDate:yyyy-MM-dd}");
    }
    Console.WriteLine();
}

static void Test10_ComplexQuery()
{
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    Console.WriteLine("Test 10: Complex Query");
    Console.WriteLine("(In Stock AND Price < 1000 AND Electronics)");
    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

    var filter = new FilterBuilder<Product>()
        .AddCondition(nameof(Product.InStock), FilterOperation.Equals, true)
        .AddCondition(nameof(Product.Price), FilterOperation.LessThan, 1000m)
        .AddCondition(nameof(Product.CategoryId), FilterOperation.Equals, 1);

    var expression = filter.Build();
    var products = SeedData.Products.AsQueryable().Where(expression).ToList();

    Console.WriteLine($"Found {products.Count} products:");
    foreach (var p in products)
    {
        Console.WriteLine($"  ✓ {p.Name}");
        Console.WriteLine($"    Price: {p.Price:C}");
        Console.WriteLine($"    In Stock: {p.InStock}");
        Console.WriteLine($"    Category: {p.CategoryId}");
    }
    Console.WriteLine();
}
*/
#endregion
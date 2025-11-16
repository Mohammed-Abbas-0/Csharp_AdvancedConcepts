using Csharp_AdvancedConcepts.DesignPattern.FactoryMethod;

var factory = new TransportFactory();

Console.WriteLine("Enter transport type (Air, Sea, Road): ");
var input = Console.ReadLine();

try
{
    // تحويل الديناميك من string إلى Enum
    var type = Enum.Parse<TransportType>(input, ignoreCase: true);

    // إنشاء النوع المناسب
    var transport = factory.Create(type);

    // تشغيل العملية
    transport.Deliver();
}
catch
{
    Console.WriteLine("Invalid transport type 😢");
}

Console.ReadLine();

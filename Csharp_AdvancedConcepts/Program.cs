using Csharp_AdvancedConcepts.DesignPattern.FactoryMethod;

// Transport Factory Usage
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


// Waybill Printer Factory Usage

var waybillFactory = new WaybillTypeFactory();

Console.WriteLine("Enter waybill printer type (1: PDF, 2: Excel, 3: Word): ");
var waybillEnum = Console.ReadLine();

try
{
    // إنشاء النوع المناسب
    var waybillCreater = waybillFactory.Create(int.Parse(waybillEnum!));

    // تشغيل العملية
    waybillCreater.Print();
}
catch
{
    Console.WriteLine("Invalid transport type 😢");
}

Console.ReadLine();
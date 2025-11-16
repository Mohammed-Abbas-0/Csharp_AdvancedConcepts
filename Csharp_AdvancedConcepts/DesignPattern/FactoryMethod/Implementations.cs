namespace Csharp_AdvancedConcepts.DesignPattern.FactoryMethod
{
    public class AirTransport : ITransport
    {
        public void Deliver() => Console.WriteLine("Delivering by airplane...");
    }

    public class SeaTransport : ITransport
    {
        public void Deliver() => Console.WriteLine("Delivering by sea ship...");
    }

    public class RoadTransport : ITransport
    {
        public void Deliver() => Console.WriteLine("Delivering by truck...");
    }


    #region Waybill Printers

    public class PDFWaybillPrinter : IWaybillPrinter
    {
        public void Print() => Console.WriteLine("Printing waybill in PDF format...");
    }
    public class ExcelWaybillPrinter : IWaybillPrinter
    {
        public void Print() => Console.WriteLine("Printing waybill in Excel format...");
    }
    public class WordWaybillPrinter : IWaybillPrinter
    {
        public void Print() => Console.WriteLine("Printing waybill in Word format...");
    }

    #endregion
}

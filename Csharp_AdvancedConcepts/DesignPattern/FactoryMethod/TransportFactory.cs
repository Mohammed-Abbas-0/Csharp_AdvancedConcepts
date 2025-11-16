namespace Csharp_AdvancedConcepts.DesignPattern.FactoryMethod
{
    public enum TransportType
    {
        Air,
        Sea,
        Road,
        Train,
        Courier
    }

    public class TransportFactory
    {
        private readonly Dictionary<TransportType, Func<ITransport>> _map
        = new()
        {
            { TransportType.Air, () => new AirTransport() },
            { TransportType.Sea, () => new SeaTransport() },
            { TransportType.Road, () => new RoadTransport() },
        };

        //public ITransport Create(string mode)
        //{
        //    //if (_map.TryGetValue(mode, out var creator))
        //    //    return creator();
        //    throw new ArgumentException($"Unknown transport type: {mode}");
        //}

        public ITransport Create(TransportType type)
        {
            return _map[type]();
        }

    }

    // Waybill Printer Factory
    public enum WaybillTypeEnum
    {
        PDF = 1,
        Excel,
        Word
    }

    // Factory Class, which creates Waybill Printers based on the WaybillType enum
    public class  WaybillTypeFactory
    {
        private Dictionary<int, Func<IWaybillPrinter>> _map = new()
        {
            { (int)WaybillTypeEnum.PDF, () => new PDFWaybillPrinter() },
            { (int)WaybillTypeEnum.Excel, () => new ExcelWaybillPrinter() },
            { (int)WaybillTypeEnum.Word, () => new WordWaybillPrinter() },
        };

        public IWaybillPrinter Create(int waybillPrinter)
        {
            return _map[waybillPrinter]();
        }
    }

}

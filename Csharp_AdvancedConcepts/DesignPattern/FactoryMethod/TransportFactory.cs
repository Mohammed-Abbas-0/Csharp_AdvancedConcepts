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
}

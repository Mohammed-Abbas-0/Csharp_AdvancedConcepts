using Csharp_AdvancedConcepts.DesignPattern.FactoryMethod;

namespace Csharp_AdvancedConcepts.DesignPattern.AbstractFactory
{
    public interface ITransportFactory
    {
        ITransport CreateHeavyTransport();
        ITransport CreateLightTransport();
    }

    public class LocalTransportFactory : ITransportFactory
    {
        public ITransport CreateHeavyTransport() => new TruckTransport();
        public ITransport CreateLightTransport() => new CourierTransport();
    }
    public class InternationalTransportFactory : ITransportFactory
    {
        public ITransport CreateHeavyTransport() => new SeaTransport();
        public ITransport CreateLightTransport() => new AirTransport();
    }

    public class TruckTransport : ITransport
    {
        public void Deliver() => Console.WriteLine("Delivering by local truck...");
    }
    public class CourierTransport : ITransport
    {
        public void Deliver() => Console.WriteLine("Delivering by local courier...");
    }
}

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

}

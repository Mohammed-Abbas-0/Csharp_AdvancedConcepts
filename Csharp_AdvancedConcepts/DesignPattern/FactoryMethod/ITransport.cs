namespace Csharp_AdvancedConcepts.DesignPattern.FactoryMethod
{
    public interface ITransport
    {
        void Deliver();
    }

    public interface IWaybillPrinter
    {
        void Print();
    }

}

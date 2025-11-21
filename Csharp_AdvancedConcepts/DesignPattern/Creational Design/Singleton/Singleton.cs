namespace Csharp_AdvancedConcepts.DesignPattern.Singleton
{
    /// <summary>
    /// Thread-Safe Singleton Implementation using Lazy<T>
    /// 
    /// When to use:
    /// - When you need exactly one instance of a class to coordinate actions across the system.
    /// - When you need strict control over how and when that instance is accessed.
    /// 
    /// Tradeoffs:
    /// - Global state can make unit testing difficult (dependencies are hidden).
    /// - Can mask bad design if overused (e.g., "God Object").
    /// </summary>
    public sealed class Singleton
    {
        // Lazy<T> provides built-in thread safety and lazy initialization.
        // It guarantees that the instance is created only when accessed for the first time,
        // and that only one thread can create it.
        private static readonly Lazy<Singleton> _lazy = 
            new Lazy<Singleton>(() => new Singleton());

        /// <summary>
        /// Public accessor for the single instance.
        /// </summary>
        public static Singleton Instance => _lazy.Value;

        /// <summary>
        /// Private constructor prevents instantiation from outside.
        /// </summary>
        private Singleton()
        {
            Console.WriteLine("Singleton instance created.");
        }

        /// <summary>
        /// Example method to demonstrate usage.
        /// </summary>
        public void DoSomething()
        {
            Console.WriteLine($"Singleton is doing something. Instance ID: {this.GetHashCode()}");
        }
    }
}

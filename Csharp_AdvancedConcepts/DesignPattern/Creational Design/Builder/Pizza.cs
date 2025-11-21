namespace Csharp_AdvancedConcepts.DesignPattern.Builder
{
    public enum PizzaSize
    {
        Small,
        Medium,
        Large
    }
    public enum PizzaCrust
    {
        Thin,
        Thick,
        Stuffed
    }
    public enum TakeAwayOption
    {
        Yes = 1,
        No
    }
    public class Pizza
    {
        public string Size { get; set; } = string.Empty;
        public string Crust { get; set; } = string.Empty;
        public List<string>? Toppings { get; set; }
        public List<string>? Sauce { get; set; }
        public bool? TakeAway { get; set; }

        public Pizza(string size, string crust, List<string>? toppings, List<string>? sauce, bool? takeAway)
        {
            Size = size;
            Crust = crust;
            Toppings = toppings;
            Sauce = sauce;
            TakeAway = takeAway;
        }
    }

    // Builder Class
    public class PizzaBuilder
    {
        private string _size = string.Empty;
        private string _crust = string.Empty;
        private List<string>? _toppings;
        private List<string>? _sauce;
        private bool? _takeAway;

        public PizzaBuilder()
        {
            
        }

        public PizzaBuilder WithSize(PizzaSize size)
        {
            _size = size.ToString();
            return this;
        }

        public PizzaBuilder WithCrust(PizzaCrust crust)
        {
            _crust = crust.ToString();
            return this;
        }
        public PizzaBuilder AddTopping(List<string> toppings)
        {
            _toppings = toppings;
            return this;
        }
        public PizzaBuilder WithSauce(List<string> sauce)
        {
            _sauce = sauce;
            return this;
        }
        public PizzaBuilder TakeAway(TakeAwayOption option)
        {
            _takeAway = option == TakeAwayOption.Yes;
            return this;
        }
        public Pizza Build()
        {
            return new Pizza(_size, _crust, _toppings, _sauce, _takeAway);
        }

    }
}

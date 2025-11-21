namespace Csharp_AdvancedConcepts.DesignPattern.PrototoType
{
    // Prototype Pattern - Deep Copy and Shallow Copy
    // Deep Copy: Creates a new object and also copies all objects referenced by the original object.
    // Shallow Copy: Creates a new object but copies only the references to the objects referenced by the original object.
    public class RealEstate : ICloneable
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public List<Furniture> Furnitures { get; set; }
        public List<RealEstateImage> Images { get; set; }

        public object Clone()
        {
            // Deep Copy manually
            return new RealEstate
            {
                Title = this.Title,
                Price = this.Price,
                City = this.City,
                Furnitures = this.Furnitures.Select(f => (Furniture)f.Clone()).ToList(),
                Images = this.Images.Select(i => (RealEstateImage)i.Clone()).ToList()
            };
        }

        public RealEstate ShallowClone()
        {
            // Shallow Copy
            return (RealEstate)this.MemberwiseClone();
        }
    }

    public class Furniture : ICloneable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public object Clone()
        {
            return new Furniture
            {
                Name = this.Name,
                Price = this.Price
            };
        }
    }

    public class RealEstateImage : ICloneable
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public object Clone()
        {
            return new RealEstateImage
            {
                FileName = this.FileName,
                FilePath = this.FilePath
            };
        }
    }
}

// Example usage:

//RealEstate realEstate = new();
//realEstate.Title = "Luxury Villa";
//realEstate.Price = 1_000_000m;
//realEstate.City = "Los Angeles";
//realEstate.Furnitures = new List<Furniture>
//{
//    new Furniture { Name = "Sofa", Price = 2000m },
//    new Furniture { Name = "Dining Table", Price = 1500m }
//};

//realEstate.Images = new List<RealEstateImage>
//{
//    new RealEstateImage { FileName = "front_view.jpg", FilePath = "/images/front_view.jpg" },
//    new RealEstateImage { FileName = "living_room.jpg", FilePath = "/images/living_room.jpg" }
//};
//var realEstateClone = (RealEstate)realEstate.Clone();

//Console.WriteLine($"Original Real Estate Title: {realEstate.Title}, Price: {realEstate.Price}, City: {realEstate.Furnitures.First().Name}");
//realEstateClone.Price = 900_000m;
//realEstateClone.Furnitures.First().Name = "Cairo";
//Console.WriteLine($"Original Real Estate Title: {realEstateClone.Title}, Price: {realEstateClone.Price}, City: {realEstateClone.Furnitures.First().Name}");
//Console.WriteLine($"Original Real Estate Title: {realEstate.Title}, Price: {realEstate.Price}, City: {realEstate.Furnitures.First().Name}");

//Console.WriteLine("-----------------------------------------------------------------------------------");


//RealEstate realEstate2 = new();
//realEstate2.Title = "Luxury Villa";
//realEstate2.Price = 1_000_000m;
//realEstate2.City = "Los Angeles";
//realEstate2.Furnitures = new List<Furniture>
//{
//    new Furniture { Name = "Sofa", Price = 2000m },
//    new Furniture { Name = "Dining Table", Price = 1500m }
//};

//realEstate2.Images = new List<RealEstateImage>
//{
//    new RealEstateImage { FileName = "front_view.jpg", FilePath = "/images/front_view.jpg" },
//    new RealEstateImage { FileName = "living_room.jpg", FilePath = "/images/living_room.jpg" }
//};
//var realEstate2Clone = realEstate2.ShallowClone();

//Console.WriteLine($"Original Real Estate Title: {realEstate2.Title}, Price: {realEstate2.Price}, City: {realEstate2.Furnitures.First().Name}");
//realEstate2Clone.Furnitures.First().Name = "Cairo";
//Console.WriteLine($"Original Real Estate Title: {realEstate2Clone.Title}, Price: {realEstate2Clone.Price}, City: {realEstate2Clone.Furnitures.First().Name}");
//Console.WriteLine($"Original Real Estate Title: {realEstate2.Title}, Price: {realEstate2.Price}, City: {realEstate2Clone.Furnitures.First().Name}");


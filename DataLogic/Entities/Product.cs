namespace DataLogic.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool InStock { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<Review> Reviews { get; set; } = new();
}

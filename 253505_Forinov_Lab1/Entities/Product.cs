namespace _253502_Forinov_Lab5.Entities;

public class Product
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Id = new Guid();
        Name = name;
        Price = price;
    }
}
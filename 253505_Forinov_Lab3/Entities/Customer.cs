namespace _253505_Forinov_Lab3.Entities;

public class Customer
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; } = new();

    public Customer(string name)
    {
        Id = new Guid();
        Name = name;
    }
}
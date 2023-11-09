namespace _253502_Forinov_Lab5.Entities;

public class Customer
{
    public Guid Id { get; init; }
    public string Name { get; set; }

    public Customer(string name)
    {
        Id = new Guid();
        Name = name;
    }
}
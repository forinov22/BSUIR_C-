namespace _253505_Forinov_Lab2.Entities;

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
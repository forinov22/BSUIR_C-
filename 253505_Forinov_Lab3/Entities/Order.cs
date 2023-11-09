namespace _253505_Forinov_Lab3.Entities;

public class Order
{
    public Guid Id { get; init; }
    public Customer Customer { get; init; }
    public Product Product { get; init; }
    public int Quantity { get; init; }

    public Order(Customer customer, Product product, int quantity)
    {
        Id = new Guid();
        Customer = customer;
        Product = product;
        Quantity = quantity;
    }
}
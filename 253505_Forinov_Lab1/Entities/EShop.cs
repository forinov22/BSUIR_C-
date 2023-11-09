using _253502_Forinov_Lab5.Collections;
using _253502_Forinov_Lab5.Contracts;

namespace _253502_Forinov_Lab5.Entities;

public class EShop : IShop
{
    private readonly MyCustomCollection<Product> _products = new();
    private readonly MyCustomCollection<Customer> _customers = new();
    private readonly MyCustomCollection<Order> _orders = new();
    
    public Customer? GetCustomerByName(string name)
    {
        Customer? customer = null;
        for (int i = 0; i < _customers.Count; i++)
            if (_customers[i].Name == name)
                customer = _customers[i];
        
        return customer;
    }
    
    public Product? GetProductByName(string name)
    {
        Product? product = null;
        for (int i = 0; i < _products.Count; i++)
            if (_products[i].Name == name)
                product = _products[i];
        
        return product;
    }

    public void AddCustomer(string name)
    {
        var customer = new Customer(name);
        _customers.Add(customer);
    }

    public void AddProduct(string name, decimal price)
    {
        var product = new Product(name, price);
        _products.Add(product);    
    }

    public void AddOrder(string customerName, string productName, int quantity)
    {
        var customer = GetCustomerByName(customerName);
        var product = GetProductByName(productName);

        if (product == null)
            throw new ArgumentException("There is no such product in collection");
        if (customer == null)
        {
            customer = new Customer(customerName);
            _customers.Add(customer);
        }

        var order = new Order(customer, product, quantity);
        _orders.Add(order);
    }

    public void ShowCustomerInfo(string name)
    {
        var customer = GetCustomerByName(name);
        if (customer == null)
        {
            Console.WriteLine($"There is no such customer with name: {name}");
            return;
        }
        
        decimal total = Decimal.Zero;
        for (var i = 0; i < _orders.Count; i++)
        {
            var order = _orders[i];
            if (customer == order.Customer)
            {
                Console.WriteLine($"{customer.Name} ordered {order.Product.Name} in the amount of {order.Quantity}");
                total += order.Product.Price * order.Quantity;
            }
        }
        Console.WriteLine($"Customer: {customer.Name};\tTotal amount : {total}");
    }

    public void ShowProductInfo(string name)
    {
        var product = GetProductByName(name);
        if (product == null)
        {
            Console.WriteLine($"There is no such product with name: {name}");
            return;
        }
        
        decimal total = Decimal.Zero;
        for (var i = 0; i < _orders.Count; i++)
        {
            var order = _orders[i];
            if (product == order.Product)
                total += product.Price * order.Quantity;
        }
        Console.WriteLine($"Product: {product.Name};\tTotal amount : {total}");
    }
}
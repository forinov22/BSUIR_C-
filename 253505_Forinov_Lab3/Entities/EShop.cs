using _253505_Forinov_Lab3.Contracts;

namespace _253505_Forinov_Lab3.Entities;

public class EShop : IShop
{
    public delegate void OrderEvent(string customerName, string productName);
    public delegate void ChangeEvent(string info);

    public event OrderEvent? OrderEventHandler;
    public event ChangeEvent? ChangeEventHandler;
    
    private readonly Dictionary<string, Product> _products = new();
    private readonly List<Customer> _customers = new();
    private readonly List<Order> _orders = new();
    
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
        foreach (var key in _products.Keys)
            if (_products[key].Name == name)
                product = _products[key];
        
        return product;
    }

    public void AddCustomer(string name)
    {
        var customer = new Customer(name);
        _customers.Add(customer);
        ChangeEventHandler?.Invoke(customer.Name);
    }

    public void AddProduct(string name, decimal price)
    {
        var product = new Product(name, price);
        _products.Add(product.Name, product);    
        ChangeEventHandler?.Invoke(product.Name);
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
        customer.Orders.Add(order);
        _orders.Add(order);
        OrderEventHandler?.Invoke(customerName, productName);
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
    
    
    /*---------------------------------*/
    public IEnumerable<string> GetProductNamesByPrice()
    {
        var collection = 
            from key in _products.Keys
            orderby _products[key].Price
            select key;
        return collection;
    }

    public decimal GetTotalSum() => _orders.Sum(o => o.Product.Price * o.Quantity);

    public decimal GetTotalSumByCustomer(string name) =>
        _orders
            .Where(o => o.Customer.Name == name)
            .Sum(o => o.Product.Price * o.Quantity);

    public string? GetCustomerWithMaxCost() =>
        _customers
            .Select(c => new { name = c.Name, cost = c.Orders.Sum(o => o.Product.Price * o.Quantity) })
            .MaxBy(t => t.cost)
            ?.name;

    public int GetCountOfCustomersWithCostHigherThan(decimal cost) =>
        _customers
            .Select(c => c.Orders.Sum(o => o.Product.Price * o.Quantity))
            .Aggregate(0, (total, next) => next > cost ? total + 1 : total);

    public void ShowCustomerPriceList(string name)
    {
        var customer = GetCustomerByName(name);
        if (customer == null)
            throw new ArgumentException($"No customer with such name: {name}");

        var productSummaries = customer.Orders
            .GroupBy(o => o.Product.Name)
            .Select(group =>
                new
                {
                    productName = group.Key,
                    totalAmount = group.Sum(o => o.Product.Price * o.Quantity)
                });

        Console.WriteLine($"Customer: \"{name}\"");
        foreach (var productSummary in productSummaries)
            Console.WriteLine($"Product: {productSummary.productName}, Total Amount Paid: {productSummary.totalAmount}");
    }
}
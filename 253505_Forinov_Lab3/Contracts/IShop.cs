using _253505_Forinov_Lab3.Entities;

namespace _253505_Forinov_Lab3.Contracts;

public interface IShop
{
    Customer? GetCustomerByName(string name);
    Product? GetProductByName(string name);
    void AddCustomer(string name);
    void AddProduct(string name, decimal price);
    void AddOrder(string customerName, string productName, int quantity);
    void ShowCustomerInfo(string name);
    void ShowProductInfo(string name);
}
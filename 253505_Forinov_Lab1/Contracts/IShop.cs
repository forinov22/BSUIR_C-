using _253502_Forinov_Lab5.Entities;

namespace _253502_Forinov_Lab5.Contracts;

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
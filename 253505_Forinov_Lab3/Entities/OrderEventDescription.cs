namespace _253505_Forinov_Lab3.Entities;

public class OrderEventDescription
{
    private string CustomerName { get; set; }
    private string ProductName { get; set; }

    public OrderEventDescription(string customerName, string productName)
    {
        CustomerName = customerName;
        ProductName = productName;
    }
    
    public string GetStringInfo() => $"{CustomerName} ordered {ProductName}";
}
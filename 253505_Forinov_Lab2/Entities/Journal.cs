using _253505_Forinov_Lab2.Collections;

namespace _253505_Forinov_Lab2.Entities;

public class Journal
{
    private readonly MyCustomCollection<OrderEventDescription> _descriptions = new();
    
    public void AddDescription(string customerName, string productName) => 
        _descriptions.Add(new OrderEventDescription(customerName, productName));

    public void ShowDescriptions()
    {
        foreach (var description in _descriptions)
            Console.WriteLine(description.GetStringInfo());
    }
}
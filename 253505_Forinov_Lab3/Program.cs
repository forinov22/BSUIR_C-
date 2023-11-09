using System.Text;
using _253505_Forinov_Lab3.Entities;

var shop = new EShop();
var journal = new Journal();

shop.ChangeEventHandler += (message) =>
    Console.WriteLine($"Entity \"{message}\" was added to shop");
shop.OrderEventHandler += journal.AddDescription;

shop.AddProduct("phone", 12000);
shop.AddProduct("headphones", 300);
shop.AddProduct("watch", 500);

shop.AddCustomer("Anton");

shop.AddOrder("Egor", "phone", 1);
shop.AddOrder("Egor", "watch", 2);
shop.AddOrder("Egor", "headphones", 2);

shop.AddOrder("Anton", "phone", 1);
shop.AddOrder("Anton", "watch", 2);
shop.AddOrder("Anton", "headphones", 1);

shop.ShowCustomerInfo("Egor");
shop.ShowProductInfo("headphones");
journal.ShowDescriptions();

Console.WriteLine("-------------------------------");
Console.WriteLine("List of product names sorted by price:");
foreach(var s in shop.GetProductNamesByPrice())
    Console.WriteLine(s);
Console.WriteLine();
Console.WriteLine($"Total sum: {shop.GetTotalSum()}");
Console.WriteLine();
Console.WriteLine($"Total sum by customer \"Anton\": {shop.GetTotalSumByCustomer("Anton")}");
Console.WriteLine();
Console.WriteLine($"Customer with max cost: \"{shop.GetCustomerWithMaxCost()}\"");
Console.WriteLine();
Console.WriteLine($"Count of customers who paid more than \"10.000\": {shop.GetCountOfCustomersWithCostHigherThan(10000)}");
Console.WriteLine();
shop.ShowCustomerPriceList("Egor");
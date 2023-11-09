using _253505_Forinov_Lab2.Collections;
using _253505_Forinov_Lab2.Entities;

var shop = new EShop();
var journal = new Journal();

shop.ChangeEventHandler += (message) =>
    Console.WriteLine($"Entity was added to shop: \"{message}\"");
shop.OrderEventHandler += journal.AddDescription;

shop.AddProduct("phone", 12000);
shop.AddProduct("headphones", 300);
shop.AddProduct("watch", 500);

shop.AddCustomer("Anton");

shop.AddOrder("Egor", "phone", 1);
shop.AddOrder("Egor", "watch", 2);
shop.AddOrder("Egor", "headphones", 1);

shop.AddOrder("Anton", "phone", 1);
shop.AddOrder("Anton", "watch", 2);
shop.AddOrder("Anton", "headphones", 1);

shop.ShowCustomerInfo("Egor");
shop.ShowProductInfo("headphones");
journal.ShowDescriptions();

var testCollection = new MyCustomCollection<int>();
try
{
    var item = testCollection[0];
    Console.WriteLine(item);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

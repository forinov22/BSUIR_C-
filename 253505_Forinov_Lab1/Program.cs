using _253502_Forinov_Lab5.Entities;

var shop = new EShop();

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

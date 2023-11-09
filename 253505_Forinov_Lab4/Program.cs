// See https://aka.ms/new-console-template for more information

using _253505_Forinov_Lab4.Models;

var fileService = new FileService();
var random = new Random();
var extensions = new[] {"txt", "rtf", "dat", "inf"};

const string dirName = "Forinov_Lab4";

if (Directory.Exists(dirName))
    Directory.Delete(dirName, true);

var dirInfo = Directory.CreateDirectory(dirName);

for (int i = 0; i < 10; i++)
{
    var randomFileName = $"file_{random.Next(1000, 9999)}";
    var ext = extensions[random.Next(4)];
    var fullFileName = $"{randomFileName}.{ext}";
    var filePath = Path.Combine(dirInfo.Name, fullFileName);
    File.Create(filePath);
}

foreach (var file in dirInfo.GetFiles())
{
    Console.WriteLine($"File: <{file.Name}> has extension <{file.Extension}>");
}

List<Car> cars = new List<Car>();

cars.Add(new Car(2022, true, "Ferrari"));
cars.Add(new Car(2020, false, "Toyota Camry"));
cars.Add(new Car(2023, true, "Porsche 911"));
cars.Add(new Car(2019, false, "Honda Civic"));
cars.Add(new Car(2021, true, "Lamborghini Huracan"));
cars.Add(new Car(2018, false, "Ford Focus"));

fileService.SaveData(cars, "cars.txt");

var newCars = fileService.ReadFile("cars.txt");

Console.WriteLine("----------------Cars from file----------------");

foreach (var car in newCars)
    car.DisplayInfo();

var comparer = new MyCustomComparer();

var sortedCars = newCars.OrderBy(car => car, comparer).ToList();


Console.WriteLine("----------------Sorted cars----------------");

foreach (var car in sortedCars)
    car.DisplayInfo();

var carsSortedByYear = newCars.OrderBy(car => car.Year).ToList();

Console.WriteLine("----------------Cars sorted by year----------------");

foreach (var car in carsSortedByYear)
    car.DisplayInfo();
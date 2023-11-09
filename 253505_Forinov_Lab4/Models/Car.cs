namespace _253505_Forinov_Lab4.Models;

public class Car
{
    // Свойство для хранения года выпуска автомобиля (тип int)
    public int Year { get; set; }

    // Свойство для хранения информации о том, является ли автомобиль спортивным (тип bool)
    public bool IsSportsCar { get; set; }

    // Свойство для хранения имени автомобиля (тип string)
    public string Name { get; set; }

    // Конструктор класса, который принимает год выпуска, информацию о типе автомобиля и имя
    public Car(int year, bool isSportsCar, string name)
    {
        Year = year;
        IsSportsCar = isSportsCar;
        Name = name;
    }

    // Метод для вывода информации о автомобиле
    public void DisplayInfo()
    {
        Console.WriteLine($"Имя автомобиля: {Name}");
        Console.WriteLine($"Год выпуска: {Year}");
        Console.WriteLine($"Спортивный автомобиль: {(IsSportsCar ? "Да" : "Нет")}");
    }
}

namespace _253505_Forinov_Lab4.Models;

public class MyCustomComparer : IComparer<Car>
{
    public int Compare(Car? x, Car? y)
    {
        if (x == null && y == null)
        {
            return 0; // Оба объекта равны
        }
        else if (x == null)
        {
            return -1; // x меньше y
        }
        else if (y == null)
        {
            return 1; // x больше y
        }
        else
        {
            string xName = x.Name;
            string yName = y.Name;

            // Сравнить значения свойства Name (независимо от регистра)
            return string.Compare(xName, yName, StringComparison.OrdinalIgnoreCase);
        }
    }
}

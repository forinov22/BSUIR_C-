namespace _253505_Forinov_Lab6.Entities;

public class Employee
{
    public string Name { get; set; }

    public int Age { get; set; }

    public bool IsManager { get; set; }

    public Employee(string name, int age, bool isManager)
    {
        Name = name;
        Age = age;
        IsManager = isManager;
    }
}

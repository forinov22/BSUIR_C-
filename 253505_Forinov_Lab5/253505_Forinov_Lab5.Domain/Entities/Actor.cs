namespace _253505_Forinov_Lab5.Domain.Entities;

public class Actor {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public Actor()
    {
        Name = "Undefined";
        Age = -1;
        Gender = "Undefined";
    }

    public Actor(string? name, int? age, string? gender)
    {
        Name = name ?? "Undefined";
        Age = age ?? -1;
        Gender = gender ?? "Undefined";
    }

    public override string ToString()
    {
        return $"Actor -> name: {Name}, age: {Age}, gender: {Gender}";
    }
}
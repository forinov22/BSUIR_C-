namespace ClassLib.Entities;

[Serializable]
public class Client
{
    public int Id { get; init; }
    public string Name { get; init; }
    public int AccountCreationYear { get; init; }

    public Client()
    {
        Id = 0;
        Name = "Undefined";
        AccountCreationYear = 0;
    }

    public Client(int id, string name, int year)
    {
        Id = id;
        Name = name;
        AccountCreationYear = year;
    }

    public override string ToString()
    {
        return $"Client {Id} -> {Name}, account created: {AccountCreationYear}";
    }
}
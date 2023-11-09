namespace _253505_Forinov_Lab5.Domain.Entities;

public class MovieCharacter : IEquatable<MovieCharacter> {
    public string Name { get; set; }
    public string Role { get; set; }
    public Actor? Actor { get; set; }

    public MovieCharacter()
    {
        Name = "Undefinded";
        Role = "Undefined";
        Actor = null;
    }

    public MovieCharacter(string? name, string? role, Actor? actor)
    {
        Name = name ?? "Undefined";
        Role = role ?? "Undefined";
        Actor = actor;
    }

    public override string ToString()
    {
        return $"MovieCharacter -> name: {Name}, role: {Role}, actor: {Actor}";
    }

    public bool Equals(MovieCharacter? other)
    {
        return Name == other?.Name && Role == other?.Role 
            && Actor?.Name == other?.Actor?.Name && Actor?.Age == other?.Actor?.Age && Actor?.Gender == other?.Actor?.Gender;
    }
}
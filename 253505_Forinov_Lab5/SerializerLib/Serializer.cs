using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using _253505_Forinov_Lab5.Domain.Entities;
using _253505_Forinov_Lab5.Domain.Interfaces;

namespace SerializerLib;

public class Serializer : ISerializer
{
    public IEnumerable<MovieCharacter> DeSerializeByLINQ(string fileName)
    {
        var document = XDocument.Load(fileName);
        var root = document.Root;

        if (root == null)
            throw new NullReferenceException("Document has null root");

        List<MovieCharacter> movieCharacters = root
            .Elements("MovieCharacter")
            .Select(e => 
                new MovieCharacter((string?)e.Element("CharacterName"), (string?)e.Element("Role"), 
                    new Actor((string?)e.Element("Actor")?.Element("ActorName"), (int?)e.Element("Actor")?.Element("Age"), (string?)e.Element("Actor")?.Element("Gender"))))
            .ToList();

        return movieCharacters;
    }

    public IEnumerable<MovieCharacter> DeSerializeXML(string fileName)
    {
        List<MovieCharacter>? movieCharacters = new();
        XmlSerializer formatter = new(typeof(List<MovieCharacter>));

        using (var stream = File.OpenRead(fileName)) {
            movieCharacters = formatter.Deserialize(stream) as List<MovieCharacter>;
        }

        if (movieCharacters == null)
            throw new NullReferenceException("Document does not contains collection");

        return movieCharacters;
    }

    public IEnumerable<MovieCharacter> DeSerializeJSON(string fileName)
    {
        List<MovieCharacter>? movieCharacters = new();
        using (var stream = File.OpenRead(fileName)) {
            movieCharacters = JsonSerializer.Deserialize<List<MovieCharacter>>(stream);
        }
        
        if (movieCharacters == null)
            throw new NullReferenceException("Document does not contains collection");

        return movieCharacters;
    }

    public void SerializeByLINQ(IEnumerable<MovieCharacter> xxx, string fileName)
    {
        XDocument document = new();
        XElement characters = new("MovieCharacters");

        foreach (var c in xxx) {
            XElement character = new("MovieCharacter");

            XElement characterName = new("CharacterName", c.Name);
            XElement role = new("Role", c.Role);

            XElement actor = new("Actor");
            XElement actorName = new("ActorName", c.Actor?.Name);
            XElement age = new("Age", c.Actor?.Age);
            XElement gender = new("Gender", c.Actor?.Gender);
            actor.Add(actorName, age, gender);

            character.Add(characterName, role, actor);
            characters.Add(character);
        }

        document.Add(characters);
        document.Save(fileName);
        System.Console.WriteLine("Xml document saved");
    }

    public void SerializeXML(IEnumerable<MovieCharacter> xxx, string fileName)
    {
        List<MovieCharacter> movieCharacters = xxx.ToList();
        XmlSerializer formatter = new(typeof(List<MovieCharacter>));

        using (var stream = File.Create(fileName)) {
            formatter.Serialize(stream, movieCharacters);
        }

        System.Console.WriteLine("Xml document saved");
    }

    public void SerializeJSON(IEnumerable<MovieCharacter> xxx, string fileName)
    {
        List<MovieCharacter> movieCharacters = xxx.ToList();

        using (var stream = File.CreateText(fileName)) {
            var json = JsonSerializer.Serialize<List<MovieCharacter>>(movieCharacters);
            stream.Write(json);
        }

        System.Console.WriteLine("Json document saved");
    }
}

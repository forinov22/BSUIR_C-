using _253505_Forinov_Lab5.Domain.Entities;

namespace _253505_Forinov_Lab5.Domain.Interfaces;

public interface ISerializer
{
    IEnumerable<MovieCharacter> DeSerializeByLINQ(string fileName);
    IEnumerable<MovieCharacter> DeSerializeXML(string fileName);
    IEnumerable<MovieCharacter> DeSerializeJSON(string fileName);
    void SerializeByLINQ(IEnumerable<MovieCharacter> xxx, string fileName);
    void SerializeXML(IEnumerable<MovieCharacter> xxx, string fileName);
    void SerializeJSON(IEnumerable<MovieCharacter> xxx, string fileName);
}
using System.Text.Json;
using _253505_Forinov_Lab6.Interfaces;

namespace FileService;

public class FileService<T> : IFileService<T> where T: class
{
    public IEnumerable<T> ReadFile(string fileName)
    {
        IEnumerable<T>? collection;

        using (var stream = File.OpenRead(fileName)) {
            collection = JsonSerializer.Deserialize<IEnumerable<T>>(stream);
        }

        if (collection == null)
            throw new NullReferenceException("There is no collection in file");

        return collection;
    }

    public void SaveData(IEnumerable<T> data, string fileName)
    {
        using (var stream = File.CreateText(fileName)) {
            var json = JsonSerializer.Serialize<IEnumerable<T>>(data);
            stream.Write(json);
        }
    }
}
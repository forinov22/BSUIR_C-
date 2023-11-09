using _253505_Forinov_Lab4.Interfaces;

namespace _253505_Forinov_Lab4.Models;

public class FileService : IFileService<Car>
{
    public IEnumerable<Car> ReadFile(string fileName)
    {
        List<Car> dataList = new();

        try
        {
            using (var stream = File.OpenRead(fileName))
            {
                var binReader = new BinaryReader(stream);
                while (binReader.BaseStream.Position < binReader.BaseStream.Length)
                {
                    var year = binReader.ReadInt32();
                    var isSportsCar = binReader.ReadBoolean();
                    var name = binReader.ReadString();
                    dataList.Add(new Car(year, isSportsCar, name));
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }

        foreach (var car in dataList)
            yield return car;
        
    }

    public void SaveData(IEnumerable<Car> data, string fileName)
    {
        if (File.Exists(fileName))
            File.Delete(fileName);


        try
        {
            using (var stream = File.Create(fileName))
            {
                var binWriter = new BinaryWriter(stream);
                foreach (var car in data)
                {
                    binWriter.Write(car.Year);
                    binWriter.Write(car.IsSportsCar);
                    binWriter.Write(car.Name);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
    }
}
